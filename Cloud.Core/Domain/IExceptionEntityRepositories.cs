using System.Collections.Generic;
using Cloud.Framework.Mongo;

namespace Cloud.Domain
{
    public interface IExceptionEntityRepositories : IMongoRepositories<ExceptionEntity>
    {
        IEnumerable<ExceptionEntity> GetEntities(bool isDistinct);
    }
}