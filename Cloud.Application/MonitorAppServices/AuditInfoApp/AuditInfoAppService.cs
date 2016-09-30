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
            var result = _mongoRepositories.GetEntities(false).Take(40).ToList();

            var item = result.Select(x => new NamespaceDto
            {
                Name = x.Id,
                Display = x.ServiceName,
                Url = x.ServiceName + "." + x.MethodName,
                Children = new[]
                {
                    new NamespaceDto("Id",x.Id,""),
                    new NamespaceDto("Exception",x.Exception?.ToString(),""),
                    new NamespaceDto("BrowserInfo",x.BrowserInfo,""),
                    new NamespaceDto("ClientIpAddress",x.ClientIpAddress,""),
                    new NamespaceDto("ClientName",x.ClientName,""),
                    new NamespaceDto("CustomData",x.CustomData,""),
                    new NamespaceDto("ExecutionDuration",x.ExecutionDuration.ToString(),""),
                    new NamespaceDto("ExecutionTime",x.ExecutionTime.ToString("yyyy/m/d HH:mm:ss"),""),
                    new NamespaceDto("Parameters",x.Parameters,""),
                    new NamespaceDto("ServiceName",x.ServiceName,""),
                    new NamespaceDto("MethodName",x.MethodName,""),
                    new NamespaceDto("UserId",x.UserId?.ToString(),"")
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