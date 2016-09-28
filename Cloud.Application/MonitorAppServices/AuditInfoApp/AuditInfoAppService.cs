using System;
using System.Collections.Generic;
using System.Linq;
using Cloud.ApiManagerServices.Manager.Dtos;
using Cloud.Domain;
using Cloud.Framework;
using Cloud.Framework.Mongo;
using Cloud.MonitorAppServices.AuditInfoApp.Dtos;

namespace Cloud.MonitorAppServices.AuditInfoApp
{
    public class AuditInfoAppService : CloudAppServiceBase, IAuditInfoAppService
    {
        private readonly IAuditinfoRepositories _mongoRepositories;

        public AuditInfoAppService(IAuditinfoRepositories mongoRepositories)
        {
            _mongoRepositories = mongoRepositories;
        }


        public AuditInfoEntity Get(string id)
        {
            return _mongoRepositories.FirstOrDefault(x => x.Id == id);
        }

        public void GetAll(GetAllInput input)
        {
            _mongoRepositories.Queryable();

        }

        public List<NamespaceDto> GetNamespace()
        {
            var page = new PageIndex
            {
                CurrentIndex = 1,
                PageSize = 20
            };
            var result = _mongoRepositories.GetEntities(false).ToPaging(page);

            var item = result.Select(x => new NamespaceDto
            {
                Name = x.Id,
                Display = x.ServiceName,
                Url = x.ServiceName + "." + x.MethodName,
                Children = new[]
                {
                    new NamespaceDto("Id",x.Exception.ToString(),""),
                    new NamespaceDto("Id",x.BrowserInfo,""),
                    new NamespaceDto("Id",x.ClientIpAddress,""),
                    new NamespaceDto("Id",x.ClientName,""),
                    new NamespaceDto("Id",x.CustomData,""),
                    new NamespaceDto("Id",x.ExecutionDuration.ToString(),""),
                    new NamespaceDto("Id",x.ExecutionTime.ToString("yyyy/m/d HH:mm:ss"),""),
                    new NamespaceDto("Id",x.Parameters,""),
                    new NamespaceDto("Id",x.ServiceName,""),
                    new NamespaceDto("Id",x.MethodName,""),
                    new NamespaceDto("Id",x.UserId.ToString(),"")
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