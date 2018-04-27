using Isaac.Infrastructure.Framework.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.App.Framework.Utils.Caches.Redis
{
    public class RedisList : RedisBase, IRdsList
    {
        public string Dequeue(string key)
        {
            return Dequeue<string>(key);
        }

        public T Dequeue<T>(string key)
        {
            var value = Core.ListLeftPop(key);
            if (value.HasValue && !string.IsNullOrEmpty(value))
            {
                return JsonConvert.DeserializeObject<T>(value.ToString());
            }
            else
            {
                return default(T);
            }
        }

        public string DequeueInverse(string key)
        {
            return DequeueInverse<string>(key);
        }

        public T DequeueInverse<T>(string key)
        {
            var value = Core.ListRightPop(key);
            if (value.HasValue && !string.IsNullOrEmpty(value))
            {
                return JsonConvert.DeserializeObject<T>(value.ToString());
            }
            else
            {
                return default(T);
            }
        }

        public void Enqueue(string key, object value)
        {
            Core.ListRightPush(key, JsonConvert.SerializeObject(value));
        }

        public void Enqueue(string key, object value, TimeSpan expireSpan)
        {
            this.Enqueue(key, value);
            this.SetExpireSpan(key, expireSpan);
        }

        public void EnqueueInverse(string key, object value)
        {
            Core.ListLeftPush(key, JsonConvert.SerializeObject(value));
        }

        public void EnqueueInverse(string key, object value, TimeSpan expireSpan)
        {
            this.EnqueueInverse(key, value);
            this.SetExpireSpan(key, expireSpan);
        }

        public long Length(string key)
        {
            return Core.ListLength(key);
        }

        public string Get(string key, long index)
        {
            return Get<string>(key, index);
        }

        public T Get<T>(string key, long index)
        {
            var result = Core.ListGetByIndex(key, index);
            if (result.HasValue && string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<T>(result);
            }
            else
            {
                return default(T);
            }
        }
    }
}
