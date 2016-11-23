using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Cloud.ApiManagerServices.Manager.Dtos;
using Cloud.Domain;
using Cloud.MonitorAppServices.NetMonitorApp.Dtos;

namespace Cloud.MonitorAppServices.NetMonitorApp
{
    public interface INetMonitorAppService : IApplicationService
    {
        void Get(string id);
        void GetAll(GetAllInput input);
        List<NamespaceDto> GetNamespace();
        Task Post(NetMonitorDto input);
    }
}