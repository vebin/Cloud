using System.Collections.Generic;
using System.Web.Http;
using Abp.Application.Services;
using Cloud.ApiManagerServices.Manager.Dtos;

namespace Cloud.User
{
    public interface IUserInfoAppService : IApplicationService
    {

        [HttpGet]
        void Get();


        List<NamespaceDto> Call();
        List<NamespaceDto> Info();
    }
}