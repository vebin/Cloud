using Cloud.Framework;
using Cloud.MonitorAppServices.ExceptionApp.Dtos;

namespace Cloud.MonitorAppServices.ExceptionApp
{
    public class ExceptionAppService : CloudAppServiceBase, IExceptionAppService
    {
        public void Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public void GetAll(GetAllInput input)
        {
            throw new System.NotImplementedException();
        }
    }
}