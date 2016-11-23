using Abp.AutoMapper;
using Cloud.Domain;

namespace Cloud.MonitorAppServices.NetMonitorApp.Dtos
{
    [AutoMap(typeof(NetMonitorEntity))]
    public class NetMonitorDto
    {
        public string Ip { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}