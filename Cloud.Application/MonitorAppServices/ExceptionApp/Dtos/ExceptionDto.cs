using Abp.AutoMapper;
using Cloud.Domain;

namespace Cloud.MonitorAppServices.ExceptionApp.Dtos
{
    [AutoMap(typeof(ExceptionEntity))]
    public class ExceptionDto
    {
        public string InnerException { get; set; }
        public string StackTrace { get; set; }
        public string Source { get; set; }
        public string Data { get; set; }
        public string Message { get; set; }
        public string HelpLink { get; set; }
        public string ExceptionType { get; set; }
    }
}