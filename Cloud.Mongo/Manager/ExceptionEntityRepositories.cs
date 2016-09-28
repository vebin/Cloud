using System.Collections.Generic;
using System.Linq;
using Cloud.Domain;
using Cloud.Mongo.Framework;

namespace Cloud.Mongo.Manager
{
    public class ExceptionEntityRepositories : MongoRepositories<ExceptionEntity, string>, IExceptionEntityRepositories
    {
        public IEnumerable<ExceptionEntity> GetEntities(bool isDistinct)
        {
            if (isDistinct)
            {
                return Queryable().OrderByDescending(x => x.CreateTime).Distinct();
            }
            else
            { 
                return Queryable().OrderByDescending(x => x.CreateTime);
            }

        }
    }
}