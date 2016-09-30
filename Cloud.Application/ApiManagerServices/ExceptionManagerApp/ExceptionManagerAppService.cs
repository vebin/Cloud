using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Json;
using Cloud.ApiManagerServices.Manager.Dtos;
using Cloud.Domain;
using Cloud.Framework;
using Cloud.Framework.Mongo;

namespace Cloud.ApiManagerServices.ExceptionManagerApp
{
    public class ExceptionManagerAppService : CloudAppServiceBase, IExceptionManagerAppService
    {
        private readonly IExceptionEntityRepositories _exceptionEntityRepositories;

        public ExceptionManagerAppService(IExceptionEntityRepositories exceptionEntityRepositories)
        {
            _exceptionEntityRepositories = exceptionEntityRepositories;
        }


        public List<NamespaceDto> GetNamespace()
        {
            var result = _exceptionEntityRepositories.GetEntities(false).Take(20).ToList();

            var item = result.Select(x => new NamespaceDto
            {
                Name = x.Id,
                Display = x.Message,
                Url = "",
                Children = new[]
                {
                    new NamespaceDto("Id",x.Id,""),
                    new NamespaceDto("HelpLink",x.HelpLink,""),
                    new NamespaceDto("ExceptionType",x.ExceptionType,""),
                    new NamespaceDto("CreateTime",x.CreateTime.ToString("yyyy/m/d HH:mm:ss"),""),
                    new NamespaceDto("Data",x.Data.ToJsonString(),"")
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

        public List<NamespaceDto> NotFriendException()
        {
            var result = _exceptionEntityRepositories.GetEntities(false).Where(x => x.ExceptionType != "UserFriendlyException").Take(40).ToList();

            var item = result.Select(x => new NamespaceDto
            {
                Name = x.Id,
                Display = x.Message,
                Url = "",
                Children = new[]
                {
                    new NamespaceDto("Id",x.Id,""),
                    new NamespaceDto("HelpLink",x.HelpLink,""),
                    new NamespaceDto("ExceptionType",x.ExceptionType,""),
                    new NamespaceDto("CreateTime",x.CreateTime.ToString("yyyy/m/d HH:mm:ss"),""),
                    new NamespaceDto("Data",x.Data.ToJsonString(),"")
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

        public List<NamespaceDto> FriendException()
        {
            var result = _exceptionEntityRepositories.GetEntities(false).Where(x => x.ExceptionType == "UserFriendlyException").Take(40).ToList();

            var item = result.Select(x => new NamespaceDto
            {
                Name = x.Id,
                Display = x.Message,
                Url = "",
                Children = new[]
                {
                    new NamespaceDto("Id",x.Id,""),
                    new NamespaceDto("HelpLink",x.HelpLink,""),
                    new NamespaceDto("ExceptionType",x.ExceptionType,""),
                    new NamespaceDto("CreateTime",x.CreateTime.ToString("yyyy/m/d HH:mm:ss"),""),
                    new NamespaceDto("Data",x.Data.ToJsonString(),"")
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

        public List<NamespaceDto> NotInvalidOperationException()
        {
            var result = _exceptionEntityRepositories.GetEntities(false).Where(x => x.ExceptionType == "InvalidOperationException").Take(40).ToList();

            var item = result.Select(x => new NamespaceDto
            {
                Name = x.Id,
                Display = x.Message,
                Url = "",
                Children = new[]
                {
                    new NamespaceDto("Id",x.Id,""),
                    new NamespaceDto("HelpLink",x.HelpLink,""),
                    new NamespaceDto("ExceptionType",x.ExceptionType,""),
                    new NamespaceDto("CreateTime",x.CreateTime.ToString("yyyy/m/d HH:mm:ss"),""),
                    new NamespaceDto("Data",x.Data.ToJsonString(),"")
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

        public List<NamespaceDto> InvalidOperationException()
        {
            var result = _exceptionEntityRepositories.GetEntities(false).Where(x => x.ExceptionType == "InvalidOperationException").Take(40).ToList();

            var item = result.Select(x => new NamespaceDto
            {
                Name = x.Id,
                Display = x.Message,
                Url = "",
                Children = new[]
                {
                    new NamespaceDto("Id",x.Id,""),
                    new NamespaceDto("HelpLink",x.HelpLink,""),
                    new NamespaceDto("ExceptionType",x.ExceptionType,""),
                    new NamespaceDto("CreateTime",x.CreateTime.ToString("yyyy/m/d HH:mm:ss"),""),
                    new NamespaceDto("Data",x.Data.ToJsonString(),"")
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