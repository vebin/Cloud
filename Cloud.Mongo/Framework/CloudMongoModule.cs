using System.Configuration;
using System.Reflection;
using Abp.Modules;
using Cloud.Framework;
using Cloud.Framework.Mongo;

namespace Cloud.Mongo.Framework
{
    [DependsOn(typeof(CloudCoreModule))]

    public class CloudMongoModule : AbpModule
    {  
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
