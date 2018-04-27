using Isaac.Infrastructure.Framework.Utils;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.App.Framework.Utils.Caches.Redis
{
    public class RedisSortedSet : RedisBase, IRdsSortedSet
    {
        public IDictionary<string, double> GetSelectedRange(string key, double cap, double floor, bool isDescending = false)
        {
            return GetSelectedRange<string>(key, cap, floor, isDescending);
        }

        public IDictionary<T, double> GetSelectedRange<T>(string key, double cap, double floor, bool isDescending = false)
            where T : IComparable<T>
        {
            var results = 
                Core.SortedSetRangeByScoreWithScores(key, cap, floor, Exclude.None, isDescending ? Order.Descending : Order.Ascending);

            if (results != null && results.Any())
            {
                Dictionary<T, double> modResults = new Dictionary<T, double>();
                foreach (var item in results)
                {
                    try
                    {
                        var modItem = JsonConvert.DeserializeObject<T>(item.Element);
                        if (!modResults.ContainsKey(modItem))
                        {
                            modResults.Add(modItem, item.Score);
                        }
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

        public long Length(string key)
        {
            return Core.SortedSetLength(key);
        }

        public void ZSetAdd(string key, object value, double score)
        {
            throw new NotImplementedException();
        }
    }
}
