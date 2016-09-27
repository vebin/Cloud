using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Cloud.ApiManagerServices.Manager.Dtos;
using Cloud.Framework.Assembly;
using Cloud.Framework.Mongo;

namespace Cloud.ApiManagerServices.Manager
{
    public interface IManagerAppService : IApplicationService
    {
        [ContentDisplay("获取最新")]
        Task<ListResultOutput<GetOutput>> GetBatch();

        [HttpGet]
        ViewDataMongoModel AllInterface();

        [HttpGet]
        ListResultOutput<OpenDocumentResponse> Interface(string actionName);

        [HttpGet]
        List<NamespaceDto> GetNamespace();

        [HttpGet]
        OpenDocumentResponse GetInfo(string input);

        TestOutput Test(TestInput input);

        [ContentDisplay("动态Js")]
        [HttpGet]
        Task<string> CloudHelper();

        [HttpGet]
        void UpdateApiManager();
    }
}