using System;
using System.Collections.Generic;
using System.Linq;
using Cloud.ApiManagerServices.Manager.Dtos;
using Cloud.Domain;
using Cloud.Framework;
using Cloud.MonitorAppServices.NetMonitorApp.Dtos;

namespace Cloud.MonitorAppServices.NetMonitorApp
{
    public class NetMonitorAppService : CloudAppServiceBase, INetMonitorAppService
    {
        private readonly INetMonitorRepositories _netMonitorRepositories;

        public NetMonitorAppService(INetMonitorRepositories netMonitorRepositories)
        {
            _netMonitorRepositories = netMonitorRepositories;
        }


        public void Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public void GetAll(GetAllInput input)
        {
            throw new System.NotImplementedException();
        }

        public List<NamespaceDto> GetNamespace()
        {
            var result = _netMonitorRepositories.GetEntities(false).Take(20).ToList();

            var item = result.Select(x => new NamespaceDto
            {
                Name = x.Id,
                Display = x.Ip,
                Url = "",
                Children = new[]
                {
                    new NamespaceDto("Id",x.Id,""), 
                    new NamespaceDto("Id",x.Ip,""), 
                    new NamespaceDto("Id",x.Key,""), 
                    new NamespaceDto("Id",x.Value,""), 
                }.ToList()
            });
            var returnValue = item.ToList();
            returnValue.ForEach(x =>
            {
                var index = x.Name.IndexOf("-", StringComparison.Ordinal);
                var id = x.Name.Substring(0, index);
                x.Name = id;

            });
            return returnValue;
        }
    }
}