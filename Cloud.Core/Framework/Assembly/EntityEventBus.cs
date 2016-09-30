using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Events.Bus.Entities;
using Abp.Events.Bus.Handlers;
using Abp.Json;
using Cloud.Domain;
using Cloud.Temp;

namespace Cloud.Framework.Assembly
{
    public class EntityEventBus :
        IEventHandler<EntityCreatedEventData<UserInfo>>,
        IEventHandler<EntityChangedEventData<UserInfo>>,
        IEventHandler<EntityDeletedEventData<UserInfo>>,
        ISingletonDependency
    {

       // private readonly ScriptDomainService _scriptDomainService;
        private static int count = 0;

        //public EntityEventBus(ScriptDomainService scriptDomainService)
        //{
        //    _scriptDomainService = scriptDomainService;
        //}


        public void HandleEvent(EntityCreatedEventData<UserInfo> eventData)
        {
            count++;
            //var result = _scriptDomainService.Physics.EntityCreatedEventData(eventData.Entity);
        }

        public void HandleEvent(EntityChangedEventData<UserInfo> eventData)
        {
            count++;
            //IocManager.Instance.Resolve<INetWorkStrategy>().Send("SqlCode", new { sql, parament });
            // var result = _scriptDomainService.Physics.EntityChangedEventData(eventData.Entity);

        }

        public void HandleEvent(EntityDeletedEventData<UserInfo> eventData)
        {
            count++;
            // var result = _scriptDomainService.Physics.EntityDeletedEventData(eventData.Entity);
        } 
    }
}
