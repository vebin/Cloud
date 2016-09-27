using System.Collections.Generic;
using Cloud.ApiManagerServices.Manager.Dtos;
using Cloud.Domain;
using Cloud.Framework;
using Cloud.Framework.Mongo;

namespace Cloud.ApiManagerServices.ExceptionManagerApp
{
    public class ExceptionManagerAppService : CloudAppServiceBase, IExceptionManagerAppService
    {
        private readonly IMongoRepositories<ExceptionEntity> _mongoRepositories;

        public ExceptionManagerAppService(IMongoRepositories<ExceptionEntity> mongoRepositories)
        {
            _mongoRepositories = mongoRepositories;
        }


        public List<NamespaceDto> GetNamespace()
        {
            _mongoRepositories.GetAllList().Sort(x=>x.CreateTime);


        }
    }
}