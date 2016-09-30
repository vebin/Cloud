using System.Collections.Generic;
using Abp.Application.Services;
using Cloud.ApiManagerServices.Manager.Dtos;
using Cloud.MonitorAppServices.ExceptionApp.Dtos;

namespace Cloud.MonitorAppServices.ExceptionApp
{
    public interface IExceptionAppService : IApplicationService
    {
        void Get(string id);

        void GetAll(GetAllInput input);

        List<NamespaceDto> GetNamespace();

        List<NamespaceDto> NotFriendException();

        List<NamespaceDto> FriendException();

        List<NamespaceDto> NotInvalidOperationException();

        List<NamespaceDto> InvalidOperationException();

        GetDetailsOutput GetDetails(GetDetailsInput input);
    }
}