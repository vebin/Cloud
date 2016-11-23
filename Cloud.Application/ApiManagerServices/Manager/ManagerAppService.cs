using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Json;
using Abp.Runtime.Session;
using Abp.UI;
using Cloud.ApiManagerServices.Manager.Dtos;
using Cloud.Domain;
using Cloud.Framework;
using Cloud.Framework.Assembly;
using Cloud.Framework.Cache.Redis;
using Cloud.Framework.Mongo;

namespace Cloud.ApiManagerServices.Manager
{
    public class ManagerAppService : AbpServiceBase, IManagerAppService
    {
        public string AssemblyJsKey() => "www.ApiManager.cn";
        private readonly IManagerMongoRepositories _managerMongoRepositories;
        private readonly IManagerUrlStrategy _managerUrlStrategy;
        private readonly IAbpSession _abpSession;
        private readonly IAssemblyStrategy _domainService;
        private readonly IRedisHelper _redisHelper;
        private readonly IEcmaScriptPacker _iecmaScriptPacker;
        private readonly TestDomainService _testDomainService;

        public ManagerAppService(
            IManagerMongoRepositories managerMongoRepositories,
            IManagerUrlStrategy managerUrlStrategy,
            IAbpSession abpSession,
            IAssemblyStrategy domainService,
            IRedisHelper redisHelper,
            IEcmaScriptPacker iecmaScriptPacker, TestDomainService testDomainService)
        {
            _managerMongoRepositories = managerMongoRepositories;
            _managerUrlStrategy = managerUrlStrategy;
            _abpSession = abpSession;
            _domainService = domainService;
            _redisHelper = redisHelper;
            _iecmaScriptPacker = iecmaScriptPacker;
            _testDomainService = testDomainService;
        }

        /// <summary>
        /// 获取多条
        /// </summary> 
        /// <returns></returns>
        public async Task<ListResultOutput<GetOutput>> GetBatch()
        {
            return new ListResultOutput<GetOutput>((await _managerMongoRepositories.GetAllListAsync()).MapTo<IReadOnlyList<GetOutput>>());
        }

        public async Task<string> CloudHelper()
        {

#if DEBUG
            return await Task.Run(() => _domainService.BuildCloudHelper(typeof(CloudApplicationModule).Assembly));
#else
            return await Task.Run(() =>
             {
                 var key = AssemblyJsKey();
                 if (_redisHelper.KeyExists(key)) return _redisHelper.StringGet(key);
                 var buildAssembly = _domainService.BuildCloudHelper(typeof(CloudApplicationModule).Assembly);
                 var zip = _iecmaScriptPacker.Pack(buildAssembly);
                 _redisHelper.StringSet(key, zip);
                 return _redisHelper.StringGet(key);
             });
#endif

        }

        private static ViewDataMongoModel _data;

        public void UpdateApiManager()
        {
            _data = Network.DoGet<ViewDataMongoModel>(_managerUrlStrategy.InitUrl);
        }

        //private ViewDataMongoModel ViewDataMongoModel => _data ?? (_data = Network.DoGet<ViewDataMongoModel>(_managerUrlStrategy.InitUrl));
        private ViewDataMongoModel ViewDataMongoModel
        {
            get
            {
                if (_data == null)
                {
                    _data = Network.DoGet<ViewDataMongoModel>(_managerUrlStrategy.InitUrl);
                    return _data;
                }
                //数据隔离
                if (CloudConfig.DataIsolation)
                {
                    return _data;
                }
                return Network.DoGet<ViewDataMongoModel>(_managerUrlStrategy.InitUrl);
            }
        }


        public ViewDataMongoModel AllInterface()
        { 
            return ViewDataMongoModel;
        }

        public ListResultOutput<OpenDocumentResponse> Interface(string actionName)
        {
            var resultList = ViewDataMongoModel.OpenDocument.Where(x => x.ControllerName == actionName);
            return new ListResultOutput<OpenDocumentResponse>(resultList.ToList());
        }

        /// <summary>
        /// 待优化
        /// </summary>
        /// <returns></returns>
        public List<NamespaceDto> GetNamespace()
        {
            var open = ViewDataMongoModel.OpenDocument;
            var areaName = open.Select(x => new { x.ControllerName, x.ControllerDisplay }).Distinct();
            return areaName.Select(node => new NamespaceDto
            {
                Name = node.ControllerName,
                Display = node.ControllerDisplay,
                Children = ViewDataMongoModel.OpenDocument.Where(x => x.ControllerName == node.ControllerName).Select(x => new NamespaceDto
                {
                    Name = x.ActionName,
                    Display = x.ActionDisplay,
                    Url = x.CallUrl
                }).ToList()
            }).ToList();
        }

        public OpenDocumentResponse GetInfo(string input)
        {
            var data = ViewDataMongoModel.OpenDocument.FirstOrDefault(x => x.CallUrl == input);
            if (data == null)
                throw new UserFriendlyException("抱歉,查询不到此接口");
            return data;
        }

        public TestOutput Test(TestInput input)
        {
            var parament = input.Data.Deserialize<Dictionary<string, string>>();
            var manager = input.MapTo<Domain.TestManager>();
            manager.Parament = parament;
            manager.CallType = input.Type == HttpReponse.Post ? "Post" : "Get";
            var result = _testDomainService.ExcuteTestAndWrite(input.Url, manager, TestType.User);
            return new TestOutput
            {
                Result = result.Result.ToJsonString(),
                ErrorCode = "200",
                Take = result.Take,
                TestType = result.TestType
            };
        }
    }
}