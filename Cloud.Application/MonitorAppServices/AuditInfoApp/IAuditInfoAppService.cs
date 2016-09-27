using Abp.Application.Services;
using Cloud.Domain;
using Cloud.MonitorAppServices.AuditInfoApp.Dtos;

namespace Cloud.MonitorAppServices.AuditInfoApp
{
    public interface IAuditInfoAppService : IApplicationService
    {
        

        AuditInfoEntity Get(string id);

        void GetAll(GetAllInput input); 

    }
}