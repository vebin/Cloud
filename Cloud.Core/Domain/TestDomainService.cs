using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;
using Abp.Json;
using Abp.UI;
using Abp.Web.Models;
using Cloud.Framework.Assembly;
using Cloud.Framework.Mongo;
using Newtonsoft.Json;

namespace Cloud.Domain
{
    public class TestDomainService : IDomainService
    {
        private readonly IMongoRepositories<InterfaceManager> _mongoRepositories;
        private readonly CommunicationDomainService _communicationDomainService;
        private readonly IManagerUrlStrategy _managerUrlStrategy;
        private readonly IManagerMongoRepositories _managerMongoRepositories;
        public TestDomainService(IMongoRepositories<InterfaceManager> mongoRepositories, CommunicationDomainService communicationDomainService, IManagerUrlStrategy managerUrlStrategy, IManagerMongoRepositories managerMongoRepositories)
        {
            _mongoRepositories = mongoRepositories;
            _communicationDomainService = communicationDomainService;
            _managerUrlStrategy = managerUrlStrategy;
            _managerMongoRepositories = managerMongoRepositories;
        }

        #region 获取

        /// <summary>
        /// 根据接口地址获取所有的测试信息
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private IEnumerable<TestManager> GeTestManagers(string url)
        {
            var mongo = _mongoRepositories.FirstOrDefault(x => x.Id == url);

            if (mongo == null)
                throw new UserFriendlyException("抱歉该接口没有存在测试环境");
            return mongo.TestManager;
        }

        /// <summary>
        /// 获取所有接口
        /// </summary>
        /// <returns></returns>
        public List<InterfaceManager> GetAllInterfaceManagers()
        {
            return _mongoRepositories.GetAllList();
        }



        /// <summary>
        /// 获取该接口最后一次成功的记录(待优化)
        /// </summary>
        /// <returns></returns>
        public TestManager GetinterfaceLastSuccess(string url)
        {
            return GeTestManagers(url).Last(x => x.CallState);
        }

        /// <summary>
        /// 获取该接口最后一次记录(待优化)
        /// </summary>
        /// <returns></returns>
        public TestManager GetinterfaceLast(string url)
        {
            return GeTestManagers(url).Last();
        }

        /// <summary>
        /// 获取该接口所有的记录(待优化)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TestManager> GetAll(string url)
        {
            return GeTestManagers(url);
        }

        #endregion

        #region 执行测试动作并记录进数据库 

        /// <summary>
        /// 执行测试
        /// </summary>
        /// <param name="url"></param>
        /// <param name="testManager"></param>
        /// <returns></returns>
        public TestManager ExcuteTest(string url, TestManager testManager)
        {
            url = _managerUrlStrategy.TestHost + url;
            var watch = new Stopwatch();
            string returnValue;
            watch.Start();
            switch (testManager.CallType)
            {
                case "Post":
                    returnValue = Network.DoPost(url, testManager.Parament.ToJsonString()).Result;
                    testManager.ContentType = "application/json";
                    testManager.CallType = "Post";
                    break;
                case "Get":
                    returnValue = Network.DoGet(url, testManager.Parament).Result;
                    testManager.CallType = "Get";
                    break;
                default:
                    throw new UserFriendlyException("没有该类型的地址");
            }
            watch.Stop();
            testManager.Take = watch.ElapsedMilliseconds;
            var result = JsonConvert.DeserializeObject<AjaxResponse<object>>(returnValue);
            testManager.Parament = testManager.Parament;
            if (!result.Success)
            {
                testManager.CallState = false;
            }
            testManager.Result = result;
            testManager.Result.Result = result.Result.ToJsonString();
            testManager.CreateTime = DateTime.Now;
            testManager.UserId = Helper.GetUser().Id;
            // back.TestEnvironment = new TestEnvironment(true);
            return testManager;
        }

        /// <summary>
        /// 执行测试并写入数据库
        /// </summary>
        /// <param name="url">测试地址</param>
        /// <param name="testManager">测试案例</param>
        /// <param name="testType">测试类型</param>
        /// <returns></returns>
        public TestManager ExcuteTestAndWrite(string url, TestManager testManager, TestType testType = TestType.Auto)
        {
            var testCast = ExcuteTest(url, testManager);
            testCast.TestType = testType;
            _managerMongoRepositories.AdditionalTestData(_managerUrlStrategy.TestHost + url, testManager);
            return testManager;
        }

        #endregion

        #region Services

        /// <summary>
        /// 测试所有接口(默认测试最后一条成功的,若没有成功的,测试最后一次测试的结果,队列测试)
        /// </summary>
        public List<TestManager> ExcuteTaskAll()
        {
            var allTestCase = GetAllInterfaceManagers();
            return (from node in allTestCase
                    let testCast = node.TestManager.LastOrDefault(x => x.CallState = true)
                    ?? node.TestManager.Last()
                    select ExcuteTestAndWrite(node.Id, testCast)).ToList();
        }

        /// <summary>
        /// 测试所有成功的接口(跳过不成功的测试)
        /// </summary>
        public List<TestManager> ExcuteTaskAllFormSuccess()
        {
            var allTestCase = GetAllInterfaceManagers();
            return (from node in allTestCase let testCast = node.TestManager.LastOrDefault(x => x.CallState = true) where testCast != null select ExcuteTestAndWrite(node.Id, testCast)).ToList();
        }

        /// <summary>
        /// 测试所有失败的接口(跳过成功的测试)
        /// </summary>
        public List<TestManager> ExcuteTaskAllFormError()
        {
            var allTestCase = GetAllInterfaceManagers();
            return (from node in allTestCase let testCast = node.TestManager.LastOrDefault(x => x.CallState = false) where testCast != null select ExcuteTestAndWrite(node.Id, testCast)).ToList();
        }

        /// <summary>
        /// 执行指定单个任务
        /// </summary>
        /// <param name="testEvent"></param>
        /// <returns></returns>
        public TestManager ExcuteTask(TestEvent testEvent)
        {
            if (testEvent.TestManager == null)
                testEvent.TestManager = GetinterfaceLastSuccess(_managerUrlStrategy.TestHost + testEvent.Url);
            return ExcuteTestAndWrite(testEvent.Url, testEvent.TestManager);
        }

        /// <summary>
        /// 执行所有未完成的
        /// </summary>
        /// <returns></returns>
        public List<TestManager> ExcuteTestNotRun()
        {
            var interList = GetAllInterfaceManagers().Select(x => x.Id);
            throw new UserFriendlyException();
        }

        /// <summary>
        /// 获取所有接口地址
        /// </summary>
        /// <returns></returns>
        public List<InterfaceManager> GetAllInterfaceUrl()
        {
            var id = _mongoRepositories.Queryable().Select(x => new InterfaceManager(x.Id));
            return id.ToList();
        }

        #endregion

    }
}