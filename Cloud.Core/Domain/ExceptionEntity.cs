using System;
using System.Collections;
using System.Reflection;
using Abp.Domain.Entities;

namespace Cloud.Domain
{
    /// <summary>
    /// 异常事件实体
    /// </summary>
    public class ExceptionEntity : Entity<string>
    {
        public override string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime CreateTime { get; set; } = DateTime.Now;

        public Exception InnerException { get; set; }
        public string StackTrace { get; set; }
        public string Source { get; set; }
        public IDictionary Data { get; set; }
        public string Message { get; set; }
        public string HelpLink { get; set; } 
        public MethodBase TargetSite { get; set; }

        public ExceptionEntity()
        {

        }
        public ExceptionEntity(Exception exception)
        {
            InnerException = exception.InnerException;
            Data = exception.Data;
            Message = exception.Message;
            HelpLink = exception.HelpLink;
            Source = exception.Source;
            StackTrace = exception.StackTrace;
            TargetSite = exception.TargetSite;   

        }

    }
}