using System.Collections.Generic;
using Abp.Application.Services;
using Cloud.ApiManagerServices.Manager.Dtos;

namespace Cloud.ApiManagerServices.ExceptionManagerApp
{
    public interface IExceptionManagerAppService : IApplicationService
    {
        List<NamespaceDto> GetNamespace();


    }
}