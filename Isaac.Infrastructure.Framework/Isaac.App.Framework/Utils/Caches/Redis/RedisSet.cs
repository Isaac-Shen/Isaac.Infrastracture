﻿using Isaac.Infrastructure.Framework.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.App.Framework.Utils.Caches.Redis
{
    public class RedisSet : RedisBase, IRdsSet
    {
        public void Add(string key, object value)
        {
            Core.SetAdd(key, JsonConvert.SerializeObject(value));
        }

        public IEnumerable<string> AllMembers(string key)
        {
            var results = Core.SetMembers(key);

            if (results != null && results.Any())
            {
                return results.OfType<string>();
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<T> AllMembers<T>(string key)
        {
            var results = AllMembers(key);
            if (results != null && results.Any())
            {
                List<T> modResults = new List<T>();
                foreach (var item in results)
                {
                    try
                    {
                        modResults.Add(JsonConvert.DeserializeObject<T>(item));
                    }
                    catch
                    {
                        continue;
                    }
                }

                return modResults;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<string> CombineDifference(string firstKey, string secondKey)
        {
            return Combine(StackExchange.Redis.SetOperation.Difference, firstKey, secondKey);
        }

        public IEnumerable<T> CombineDifference<T>(string firstKey, string secondKey)
        {
            return Combine<T>(StackExchange.Redis.SetOperation.Difference, firstKey, secondKey);
        }

        public IEnumerable<string> CombineIntersect(string firstKey, string secondKey)
        {
            return Combine(StackExchange.Redis.SetOperation.Intersect, firstKey, secondKey);
        }

        public IEnumerable<T> CombineIntersect<T>(string firstKey, string secondKey)
        {
            return Combine<T>(StackExchange.Redis.SetOperation.Intersect, firstKey, secondKey);
        }

        public IEnumerable<string> CombineUnion(string firstKey, string secondKey)
        {
            return Combine(StackExchange.Redis.SetOperation.Union, firstKey, secondKey);
        }

        public IEnumerable<T> CombineUnion<T>(string firstKey, string secondKey)
        {
            return Combine<T>(StackExchange.Redis.SetOperation.Union, firstKey, secondKey);
        }

        protected virtual IEnumerable<string> Combine(StackExchange.Redis.SetOperation setOperation, string firstKey, string secondKey)
        {
            return Combine<string>(setOperation, firstKey, secondKey);
        }

        protected virtual IEnumerable<T> Combine<T>(StackExchange.Redis.SetOperation setOperation, string firstKey, string secondKey)
        {
            var results = Core.SetCombine(setOperation, firstKey, secondKey);

            if (results != null && results.Any())
            {
                List<T> modResults = new List<T>();

                foreach (var item in results)
                {
                    try
                    {
                        modResults.Add(JsonConvert.DeserializeObject<T>(item));
                    }
                    catch
                    {
                        continue;
                    }
                }

                return modResults;
            }
            else
            {
                return null;
            }
        }

        public bool Contains(string key, object value)
        {
            return Core.SetContains(key, JsonConvert.SerializeObject(value));
        }

        public long Length(string key)
        {
            return Core.SetLength(key);
        }

        public void Move(string srcKey, string destKey, object value)
        {
            Core.SetMove(srcKey, destKey, JsonConvert.SerializeObject(value));
        }

        public string Pop(string key)
        {
            return Pop<string>(key);
        }

        public T Pop<T>(string key)
        {
            var result = Core.SetPop(key);

            if (result.HasValue && string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<T>(result.ToString());
            }
            else
            {
                return default(T);
            }
        }

        public void Remove(string key, object value)
        {
            Core.SetRemove(key, JsonConvert.SerializeObject(value));
        }
    }
}
