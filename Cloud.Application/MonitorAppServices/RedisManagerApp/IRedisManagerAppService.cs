using System.Collections.Generic;
using Abp.Application.Services;
using Cloud.ApiManagerServices.Manager.Dtos;

namespace Cloud.MonitorAppServices.RedisManagerApp
{
    public interface IRedisManagerAppService : IApplicationService
    {
        List<NamespaceDto> GetNamespace();
        List<NamespaceDto> GetNamespaceBase();
        List<NamespaceDto> Remove();
    }
}