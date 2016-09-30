using System;
using Abp.Auditing;
using Abp.Domain.Entities;

namespace Cloud.Domain
{
    /// <summary>
    /// 审计日志实体
    /// </summary>
    public class AuditInfoEntity : IEntity<string>
    {
        public bool IsTransient() => true;
        public string TenantId { get; set; }
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public dynamic Exception { get; set; }
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
        public AuditInfoEntity()
        {

        }

        public AuditInfoEntity(AuditInfo auditInfo)
        {
            Exception = auditInfo.Exception;
            BrowserInfo = auditInfo.BrowserInfo;
            ClientIpAddress = auditInfo.ClientIpAddress;
            ClientName = auditInfo.ClientName;
            CustomData = auditInfo.CustomData;
            ExecutionDuration = auditInfo.ExecutionDuration;
            ExecutionTime = auditInfo.ExecutionTime;
            Parameters = auditInfo.Parameters;
            ServiceName = auditInfo.ServiceName;
            MethodName = auditInfo.MethodName;
            UserId = auditInfo.UserId;
        }
    }
}