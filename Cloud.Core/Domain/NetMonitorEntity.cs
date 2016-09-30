using System;
using Abp.Domain.Entities;
using Cloud.Framework.Mongo;
using Newtonsoft.Json;

namespace Cloud.Domain
{
    public class NetMonitorEntity : Entity<string>
    {
        public override string Id { get; set; } = Guid.NewGuid().ToString().Trim('-');

        public string Ip { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public DateTime CreateTime { get; set; }

        public NetMonitorEntity()
        {

        }

        public NetMonitorEntity(string sql, object value)
        {
            Key = sql;
            Value = JsonConvert.SerializeObject(value);

        }

    }
}