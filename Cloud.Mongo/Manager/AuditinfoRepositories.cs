using System.Collections.Generic;
using Cloud.Domain;
using Cloud.Mongo.Framework;
using System.Linq;

namespace Cloud.Mongo.Manager
{
    public class AuditinfoRepositories : MongoRepositories<AuditInfoEntity>, IAuditinfoRepositories
    {
        public IEnumerable<AuditInfoEntity> GetEntities(bool isDistinct)
        {
            return isDistinct ? Queryable().OrderByDescending(x => x.ExecutionTime).Distinct() : Queryable().OrderByDescending(x => x.ExecutionTime);
        }
    }
}