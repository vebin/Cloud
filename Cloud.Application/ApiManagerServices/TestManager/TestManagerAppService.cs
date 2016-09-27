using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.UI;
using Cloud.ApiManagerServices.TestManager.Dtos;
using Cloud.Domain;

namespace Cloud.ApiManagerServices.TestManager
{
    public class TestManagerAppService : AbpServiceBase, ITestManagerAppService
    {
        private readonly IManagerMongoRepositories _managerMongoRepositories;
        private readonly IManagerUrlStrategy _managerUrlStrategy;
        private readonly TestDomainService _testDomainService;

        public TestManagerAppService(
            IManagerMongoRepositories managerMongoRepositories,
            IManagerUrlStrategy managerUrlStrategy,
            TestDomainService testDomainService
            )
        {
            _managerMongoRepositories = managerMongoRepositories;
            _managerUrlStrategy = managerUrlStrategy;
            _testDomainService = testDomainService;
        }

        public TestManagerDto Get(IdInput<string> input)
        {
            var exists = _managerMongoRepositories.Queryable().FirstOrDefault(x => x.Id == input.Id);
            if (exists == null)
                throw new UserFriendlyException("没有对该接口进行测试");
            var data = exists.TestManager.OrderByDescending(x => x.CreateTime)
                  .FirstOrDefault(x => true);
            if (data == null)
                throw new UserFriendlyException("没有生成成功的案例！");
            return data.MapTo<TestManagerDto>();
        }


        public ListResultOutput<TestManagerDto> GetAll(GetAllInput input)
        {
            input.Id = _managerUrlStrategy.TestHost + input.Id;
            var exists = _managerMongoRepositories.Queryable().FirstOrDefault(x => x.Id == input.Id);
            if (exists == null)
                throw new UserFriendlyException("没有对该接口进行测试");
            var data = exists.TestManager.OrderByDescending(x => x.CreateTime).Take(input.PageSize).ToList();
            if (data == null)
                throw new UserFriendlyException("没有生成成功的案例！");
            return new ListResultOutput<TestManagerDto>(data.MapTo<IReadOnlyList<TestManagerDto>>());
        }

        /// <summary>
        /// 发送单此测试案例
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<TestManagerDto> SelectOneTest(SelectOneTestInput input)
        {
            var testValue = input.MapTo<TestEvent>();
            testValue.TestManager = input.Parament.MapTo<Domain.TestManager>();
            return await Task.Run(() => _testDomainService.ExcuteTask(testValue).MapTo<TestManagerDto>());
        }

        /// <summary>
        /// 测试所有
        /// </summary>
        /// <returns></returns>
        public Task<List<TestManagerDto>> TestAll()
        {
            return Task.Run(() => _testDomainService.ExcuteTaskAll().MapTo<List<TestManagerDto>>());
        }

        /// <summary>
        /// 测试所有成功的
        /// </summary>
        /// <returns></returns>
        public Task<List<TestManagerDto>> TestAllSuccess()
        {
            return Task.Run(() => _testDomainService.ExcuteTaskAllFormSuccess().MapTo<List<TestManagerDto>>());
        }

        /// <summary>
        /// 测试所有失败的
        /// </summary>
        /// <returns></returns>
        public Task<List<TestManagerDto>> TestAllError()
        {
            return Task.Run(() => _testDomainService.ExcuteTaskAllFormError().MapTo<List<TestManagerDto>>());
        }
    }
}