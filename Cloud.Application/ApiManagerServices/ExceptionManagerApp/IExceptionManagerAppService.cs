﻿using System.Collections.Generic;
using Abp.Application.Services;
using Cloud.ApiManagerServices.Manager.Dtos;
using Cloud.Framework;

namespace Cloud.ApiManagerServices.ExceptionManagerApp
{
    public interface IExceptionManagerAppService : IApplicationService
    {
        List<NamespaceDto> GetNamespace();

        List<NamespaceDto> NotFriendException();

        List<NamespaceDto> FriendException();
         
        List<NamespaceDto> NotInvalidOperationException();

        List<NamespaceDto> InvalidOperationException();
    }
}