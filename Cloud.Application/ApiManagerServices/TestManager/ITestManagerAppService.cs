using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Cloud.ApiManagerServices.TestManager.Dtos;
using Cloud.Framework.Assembly;

namespace Cloud.ApiManagerServices.TestManager
{
    /// <summary>
    /// 接口测试
    /// </summary>
    public interface ITestManagerAppService : IApplicationService
    {
        [ContentDisplay("根据Id获取最后一次成功的测试案例")]
        TestManagerDto Get(IdInput<string> input);

        [ContentDisplay("按分页获取测试案例，带状态")]
        ListResultOutput<TestManagerDto> GetAll(GetAllInput input);

        [ContentDisplay("选择测试,单点测试")]
        Task<TestManagerDto> SelectOneTest(SelectOneTestInput input);

        [ContentDisplay("批量测试的接口")]
        Task<List<TestManagerDto>> TestAll();

        [ContentDisplay("批量测试成功的接口")]
        Task<List<TestManagerDto>> TestAllSuccess();

        [ContentDisplay("批量测试失败的接口")]
        Task<List<TestManagerDto>> TestAllError();

        [ContentDisplay("获取所有未测试的接口")]
        Task<List<TestManagerDto>> GetNotTest();

    }
}
