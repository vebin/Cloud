using System.Collections.Generic;
using Cloud.Domain;
using Cloud.Mongo.Framework;
using System.Linq;

namespace Cloud.Mongo.Manager
{
    public class NetMonitorRepositories : MongoRepositories<NetMonitorEntity>, INetMonitorRepositories
    {
        public IEnumerable<NetMonitorEntity> GetEntities(bool isDistinct)
        {
            return isDistinct ? Queryable().OrderByDescending(x => x.CreateTime).Distinct() : Queryable().OrderByDescending(x => x.CreateTime);
        }
    }
}