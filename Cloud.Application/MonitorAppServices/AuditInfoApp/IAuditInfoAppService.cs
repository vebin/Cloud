using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Cloud.ApiManagerServices.Manager.Dtos;
using Cloud.Domain;
using Cloud.Framework.Assembly;
using Cloud.MonitorAppServices.AuditInfoApp.Dtos;

namespace Cloud.MonitorAppServices.AuditInfoApp
{
    public interface IAuditInfoAppService : IApplicationService
    {


        AuditInfoEntity Get(string id);

        void GetAll(GetAllInput input);

        List<NamespaceDto> GetNamespace();

        [ContentDisplay("提交审计日志")]
        Task Post(AuditInfoDto id);
    }
}