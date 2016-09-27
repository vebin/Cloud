using Abp.Application.Services;
using Cloud.MonitorAppServices.ExceptionApp.Dtos;

namespace Cloud.MonitorAppServices.ExceptionApp
{
    public interface IExceptionAppService : IApplicationService
    {
        void Get(string id);

        void GetAll(GetAllInput input);
    }
}