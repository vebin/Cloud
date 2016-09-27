using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Cloud.ApiManagerServices.Manager.Dtos;
using Cloud.Domain;
using Cloud.Framework.Assembly;

namespace Cloud.ApiManagerServices.TestManager.Dtos
{
    [AutoMap(typeof(TestEvent))]
    public class SelectOneTestInput
    {
        [Required]
        [ContentDisplay("测试地址")]
        public string Url { get; set; }

        [ContentDisplay("输入测试案例,|此接口最后一次测试成功的结果")]
        public TestInput Parament { get; set; }
    }
}