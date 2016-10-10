using System.Collections.Generic;
using System.Linq;
using Abp;
using Abp.Events.Bus;
using Abp.Events.Bus.Entities;
using Cloud.ApiManagerServices.Manager.Dtos;
using Cloud.Domain;
using Cloud.Framework.Assembly;

namespace Cloud.User
{
    public class UserInfoAppService : AbpServiceBase, IUserInfoAppService
    {
        private readonly IEventBus _eventBus;

        public UserInfoAppService(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }


        public void Get()
        {
            //_eventBus.Trigger(new EntityChangedEventData<UserInfo>(new UserInfo()));
            //_eventBus.Trigger(new EntityCreatedEventData<UserInfo>(new UserInfo()));
            //_eventBus.Trigger(new EntityDeletedEventData<UserInfo>(new UserInfo()));
        }

        public List<NamespaceDto> Call()
        {  
            var item = new List<NamespaceDto>()
            {
                new NamespaceDto("CallMyPhone","是否拨打我的电话","")
                {
                    Children = new []
                    {
                        new NamespaceDto("13681555395","确定","Confirm"),
                        new NamespaceDto("Close","取消","Close")
                    }
                }

            }; 
            return item.ToList(); 
        }

        public List<NamespaceDto> Info()
        {
            var item = new List<NamespaceDto>()
            {
                new NamespaceDto("WIKI","帮助文档(点开有惊喜)","")
                {
                    Children = new []
                    {
                        new NamespaceDto("其实我也不怎么会用耶!","OK",""),
                        new NamespaceDto("如果你会用,就告诉我呀","No","")
                    }
                }

            };
            return item.ToList();

        }
    }
}