using System;
using System.Collections;
using System.Reflection;
using System.Runtime.Serialization;
using Abp.Domain.Entities;
using Newtonsoft.Json;

namespace Cloud.Domain
{
    /// <summary>
    /// 异常事件实体
    /// </summary>
    public class ExceptionEntity : Entity<string>
    {
        public override string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public string InnerException { get; set; }
        public string StackTrace { get; set; }
        public string Source { get; set; }
        public string Data { get; set; }
        public string Message { get; set; }
        public string HelpLink { get; set; }
        public string ExceptionType { get; set; }

        public ExceptionEntity()
        {

        }
        public ExceptionEntity(Exception exception)
        {
            InnerException = exception.InnerException == null ? null : JsonConvert.SerializeObject(exception.InnerException);
            Data = JsonConvert.SerializeObject(exception.Data);
            Message = exception.Message;
            HelpLink = exception.HelpLink;
            Source = exception.Source;
            StackTrace = exception.StackTrace;
            ExceptionType = exception.GetType().Name;
        }

    }
}