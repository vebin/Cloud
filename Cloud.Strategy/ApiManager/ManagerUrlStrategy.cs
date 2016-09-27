﻿using System.Collections.Generic;
using Cloud.Domain;
using Cloud.Framework.Strategy;
using Cloud.Strategy.Framework;

namespace Cloud.Strategy.ApiManager
{
    public class ManagerUrlStrategy : StrategyBase, IManagerUrlStrategy
    {
        public Dictionary<string, string> GetDictionary;

        public string AllInterface => GetDictionary["allInterface"];
        public string Interface => GetDictionary["interface"];
        public string GetNamespace => GetDictionary["getNamespace"];
        public string LoginUrl => GetDictionary["initUrl"];
        public string InitUrl => GetDictionary["initUrl"];
        public string TestHost => GetDictionary["testHost"];
        public void Init(Dictionary<string, string> dictionary)
        {
            GetDictionary = dictionary;
        }
    }
}