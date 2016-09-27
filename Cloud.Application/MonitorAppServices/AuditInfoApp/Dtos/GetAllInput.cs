using Abp.Auditing;
using Abp.AutoMapper;
using Cloud.Domain;
using Cloud.Framework;

namespace Cloud.MonitorAppServices.AuditInfoApp.Dtos
{
    [AutoMap(typeof(AuditInfoEntity))]
    public class GetAllInput : PageIndex
    {
        public string Exception { get; set; }
        public string BrowserInfo { get; set; }
        public string ClientIpAddress { get; set; }
        public string ClientName { get; set; }
        public string CustomData { get; set; }
        public string ExecutionDuration { get; set; }
        public string ExecutionTime { get; set; }
        public string Parameters { get; set; }
        public string ServiceName { get; set; }
        public string MethodName { get; set; }
        public string UserId { get; set; }

    }
}