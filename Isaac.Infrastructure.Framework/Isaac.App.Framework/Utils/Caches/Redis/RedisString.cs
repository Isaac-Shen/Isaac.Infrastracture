using Isaac.Infrastructure.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Isaac.App.Framework.Utils.Caches.Redis
{
    public class RedisString : RedisBase, IRdsString
    {
        public void AppendStrValue(string key, string Value)
        {
            throw new NotImplementedException();
        }

        public string GetStrValue(string Key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetStrValues(IEnumerable<string> keys)
        {
            throw new NotImplementedException();
        }

        public void PrependStrValue(string key, string Value)
        {
            throw new NotImplementedException();
        }

        public void SetStrValue(string Key, string Value)
        {
            throw new NotImplementedException();
        }

        public void SetStrValue(string Key, string Value, TimeSpan ExpireSpan)
        {
            throw new NotImplementedException();
        }
    }
}
