using System;
using Abp.AutoMapper;
using Cloud.Domain;

namespace Cloud.MonitorAppServices.AuditInfoApp.Dtos
{
    [AutoMap(typeof(AuditInfoEntity))]
    public class AuditInfoDto
    {
        public string TenantId { get; set; }
        public string Exception { get; set; }
        public string BrowserInfo { get; set; }
        public string ClientIpAddress { get; set; }
        public string ClientName { get; set; }
        public string CustomData { get; set; }
        public int ExecutionDuration { get; set; }
        public DateTime ExecutionTime { get; set; }
        public string Parameters { get; set; }
        public string ServiceName { get; set; }
        public string MethodName { get; set; }
        public long? UserId { get; set; }
    }
}