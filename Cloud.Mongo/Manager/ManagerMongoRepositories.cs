﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cloud.Domain;
using Cloud.Mongo.Framework;
using MongoDB.Driver;

namespace Cloud.Mongo.Manager
{
    public class ManagerMongoRepositories : MongoRepositories<InterfaceManager, string>, IManagerMongoRepositories
    {
        /// <summary>
        /// 往测试数据中追加数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="addManager"></param>
        /// <returns></returns>
        public  void AdditionalTestData(string url, TestManager addManager)
        {
         
            var data = Queryable().FirstOrDefault(x => x.Id == url);
            if (data == null)
                  Collection.InsertOne(new InterfaceManager { Id = url, TestManager = new List<TestManager> { addManager } });
            else
                 Collection.FindOneAndUpdate(x => x.Id == url, Builders<InterfaceManager>.Update.Push(x => x.TestManager, addManager));
        }
    }
}