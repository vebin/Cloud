using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Json;
using Abp.UI;
using Cloud.ApiManagerServices.Manager.Dtos;
using Cloud.Domain;
using Cloud.Framework;
using Cloud.MonitorAppServices.ExceptionApp.Dtos;

namespace Cloud.MonitorAppServices.ExceptionApp
{
    public class ExceptionAppService : CloudAppServiceBase, IExceptionAppService
    {

        private readonly IExceptionEntityRepositories _exceptionEntityRepositories;

        public ExceptionAppService(IExceptionEntityRepositories exceptionEntityRepositories)
        {
            _exceptionEntityRepositories = exceptionEntityRepositories;
        }


        public void Get(string id)
        {
            throw new NotImplementedException();
        }

        public void GetAll(GetAllInput input)
        {
            throw new NotImplementedException();
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
                var id = x.Name.Substring(0, x.Name.IndexOf("-", StringComparison.Ordinal));
                x.Name = id;

            });
            return returnValue;
        }

        public GetDetailsOutput GetDetails(GetDetailsInput input)
        {
            var result = _exceptionEntityRepositories.FirstOrDefault(input.Url);
            if (result == null)
                throw new UserFriendlyException("Null");

            var output = new GetDetailsOutput();
            output.Display = result.Message;
            output.Name = result.Id.Substring(0, result.Id.IndexOf("-", StringComparison.Ordinal));
            output.Details = new[]
            {
                new GetDetailsOutput("Id",result.Id,TypeState.Input),
                new GetDetailsOutput("Message",result.Message,TypeState.Input),
                new GetDetailsOutput("ExceptionType",result.ExceptionType,TypeState.Input),
                new GetDetailsOutput("HelpLink",result.HelpLink,TypeState.Input),
                new GetDetailsOutput("Source",result.Source,TypeState.Input),
                new GetDetailsOutput("CreateTime",result.CreateTime.ToString("yy-MM-dd HH:mm:ss"),TypeState.DateTime),
                new GetDetailsOutput("InnerException",result.InnerException,TypeState.Input),
                new GetDetailsOutput("StackTrace",result.StackTrace,TypeState.MaxText),
                new GetDetailsOutput("Data",result.Data,TypeState.MaxText),
            };

            return output;

        }
    }
}