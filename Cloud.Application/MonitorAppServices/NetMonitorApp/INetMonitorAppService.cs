using System.Collections.Generic;
using Abp.Application.Services;
using Cloud.ApiManagerServices.Manager.Dtos;
using Cloud.MonitorAppServices.NetMonitorApp.Dtos;

namespace Cloud.MonitorAppServices.NetMonitorApp
{
    public interface INetMonitorAppService : IApplicationService
    {
        void Get(string id);

        void GetAll(GetAllInput input);


        List<NamespaceDto> GetNamespace();
    }
}