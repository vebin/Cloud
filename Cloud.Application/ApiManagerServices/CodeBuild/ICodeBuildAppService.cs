using System.Collections.Generic;
using System.Web.Http;
using Abp.Application.Services;

namespace Cloud.ApiManagerServices.CodeBuild
{
    public interface ICodeBuildAppService : IApplicationService
    {
        [HttpGet]
        void BuildCode(string tableName);



        [HttpGet]
        Dictionary<string, string> BuilDictionary(string tableName);
    }
}