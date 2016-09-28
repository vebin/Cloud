using System;
using System.Collections.Generic;
using System.Linq;
using Cloud.ApiManagerServices.Manager.Dtos;
using Cloud.Framework;
using Cloud.Framework.Cache.Redis;

namespace Cloud.MonitorAppServices.RedisManagerApp
{
    public class RedisManagerAppService : CloudAppServiceBase, IRedisManagerAppService
    {

        private readonly IRedisHelper _redisHelper;

        public RedisManagerAppService(IRedisHelper redisHelper)
        {
            _redisHelper = redisHelper;
        }

        public List<NamespaceDto> GetNamespace()
        {
            var result = _redisHelper.Keys();

            var item = result.Select(x => new NamespaceDto
            {
                Name = x,
                Display = "",
                Url = x,
                Children = new[]
                {
                    new NamespaceDto("Id",x,"")
                }
            });
            var returnValue = item.ToList();
            return returnValue;
        }

        /// <summary>
        /// 后期优化
        /// </summary>
        /// <returns></returns>

        public List<NamespaceDto> GetNamespaceBase()
        {
            var result = _redisHelper.Keys("CloudMasterKey:*");

            var item = result.Select(x => new NamespaceDto
            {
                Name = GetGuid(),
                Display = x,
                Url = x,
                Children = _redisHelper.HashGetAll(x).Where(w => w.Key != "__entityItself").Select(y => new NamespaceDto
                {
                    Name = y.Key,
                    Display = y.Value
                }).ToList()
            });
            return item.ToList();
        }

        public List<NamespaceDto> Remove()
        {
            var item = new List<NamespaceDto>()
            {
                new NamespaceDto("Remove","是否清除所有缓存","")
                {
                    Children = new []
                    {
                        new NamespaceDto("OK","确定","Confirm"),
                        new NamespaceDto("Close","取消","Close")
                    }
                }

            };
            return item.ToList();
        }

        public static string GetGuid()
        {
            var id = Guid.NewGuid().ToString();
            var index = id.IndexOf("-", StringComparison.Ordinal);
            var nid = id.Substring(0, index);
            return nid;
        }
    }
}