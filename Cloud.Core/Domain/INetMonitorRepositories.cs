using System.Collections.Generic;
using Cloud.Framework.Mongo;

namespace Cloud.Domain
{
    public interface INetMonitorRepositories : IMongoRepositories<NetMonitorEntity>
    {
        IEnumerable<NetMonitorEntity> GetEntities(bool isDistinct);
    }
}