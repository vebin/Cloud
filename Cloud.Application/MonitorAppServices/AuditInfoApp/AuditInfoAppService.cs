using Cloud.Domain;
using Cloud.Framework;
using Cloud.Framework.Mongo;
using Cloud.MonitorAppServices.AuditInfoApp.Dtos;

namespace Cloud.MonitorAppServices.AuditInfoApp
{
    public class AuditInfoAppService : CloudAppServiceBase, IAuditInfoAppService
    {
        private readonly IMongoRepositories<AuditInfoEntity> _mongoRepositories;

        public AuditInfoAppService(IMongoRepositories<AuditInfoEntity> mongoRepositories)
        {
            _mongoRepositories = mongoRepositories;
        }

        public AuditInfoEntity Get(string id)
        {
            return _mongoRepositories.FirstOrDefault(x => x.Id == id);
        }

        public void GetAll(GetAllInput input)
        {
            _mongoRepositories.Queryable();

        }
    }
}