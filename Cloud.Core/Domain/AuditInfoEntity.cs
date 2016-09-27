using System;
using Abp.Auditing;
using Abp.Domain.Entities;

namespace Cloud.Domain
{
    /// <summary>
    /// 审计日志实体
    /// </summary>
    public class AuditInfoEntity : AuditInfo, IEntity<string>
    {
        public bool IsTransient() => true;

        public string Id { get; set; } = Guid.NewGuid().ToString();

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