using Abp.AutoMapper;
using Cloud.Domain;

namespace Cloud.ApiManagerServices.Manager.Dtos
{
    [AutoMap(typeof(TestResult))]
    public class TestOutput
    {
        public string ErrorCode { get; set; } 
        public string Result { get; set; }
        public long Take { get; set; }

        public TestType TestType { get; set; }

    }
}