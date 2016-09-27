using System;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Runtime.Session;
using Abp.UI;
using Cloud.Domain;
using Jil;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Cloud.Temp;
using Neo.IronLua;

namespace Cloud.Framework.Assembly
{
    public static class Helper
    {
        #region Core

        public static bool SignIn()
        {
            var session = IocManager.Instance.Resolve<IAbpSession>();
            return session.UserId != null;
        }

        public static string Serialize<T>(this T t)
        {
            return JSON.Serialize(t);
        }

        public static T Deserialize<T>(this string str)
        {
            return JSON.Deserialize<T>(str);
        }

        public static UserInfo GetUser()
        {
            return new UserInfo()
            {
                CreateTime = DateTime.Now,
                Email = "444821531@qq.com",
                Enable = 1,
                Id = 1,
                Password = "123456",
                Role = 0,
                UserName = "jyf"
            };
        }

        #endregion
    }
    public static class TableObject
    {
        public static LuaTable GetTable(params string[] fields)
        {
            var types = new LuaTable();
            foreach (var t in fields)
            {
                types.ArrayList.Add(t);
            }
            return types;
        }

        public static LuaTable GetTable(params int[] fields)
        {
            var types = new LuaTable();
            foreach (var t in fields)
            {
                types.ArrayList.Add(t);
            }
            return types;
        }

        public static LuaTable GetTable(params object[] fields)
        {
            var types = new LuaTable();
            foreach (var t in fields)
            {
                types.ArrayList.Add(t);
            }
            return types;
        }

        public static LuaTable ToLuaTable(this Entity entity)
        {
            var types = new LuaTable();
            foreach (var t in entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                types.Members.Add(new KeyValuePair<string, object>(t.Name, t.GetValue(entity)));
            }
            return types;
        }
    }
}