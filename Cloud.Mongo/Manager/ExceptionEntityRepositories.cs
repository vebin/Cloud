using Cloud.Domain;
using Cloud.Mongo.Framework;

namespace Cloud.Mongo.Manager
{
    public class ExceptionEntityRepositories : MongoRepositories<ExceptionEntity, string>, IExceptionEntityRepositories
    {

    }
}