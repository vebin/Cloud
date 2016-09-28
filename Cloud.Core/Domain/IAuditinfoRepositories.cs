using System.Collections.Generic;
using Cloud.Framework.Mongo;

namespace Cloud.Domain
{
    public interface IAuditinfoRepositories : IMongoRepositories<AuditInfoEntity>
    {
        IEnumerable<AuditInfoEntity> GetEntities(bool b);
    }
}