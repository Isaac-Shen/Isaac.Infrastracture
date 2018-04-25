using Isaac.Infrastructure.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace Isaac.App.Framework.Utils.Caches.Redis
{
    /// <summary>
    /// 还需要考虑到集群与物理的差距
    /// </summary>
    public abstract class RedisBase : IRedisCache
    {
        protected int _currentDatabase = -1;
        protected object _currentAsyncState = null;

        protected IDatabase Core
        {
            get
            {
                return RedisManager.GetClient(_currentDatabase, _currentAsyncState);
            }
        }

        public void SwitchTo(int database, object asyncState = null)
        {
            _currentDatabase = database;
            _currentAsyncState = asyncState;
        }

        public virtual bool ContainsKey(string key)
        {
            return Core.KeyExists(key);
        }

        public virtual T GetValue<T>(string key)
        {
            var result = Core.StringGet(key);
            if (result.HasValue)
            {
                try
                {
                    var resultObj = JsonConvert.DeserializeObject<T>(result.ToString());

                    return resultObj;
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
            else
            {
                return default(T);
            }
        }

        public virtual void RemoveKey(string key)
        {
            Core.KeyDelete(key);
        }

        public virtual void Save()
        {
            Core.Execute("Save");
        }

        public virtual Task SaveAsync()
        {
            return Core.ExecuteAsync("Save");
        }

        public virtual void SetValue(string key, object value)
        {
            Core.StringSet(key, JsonConvert.SerializeObject(value), null, When.Always, CommandFlags.FireAndForget);
        }

        public virtual void SetValue(string key, object value, TimeSpan expireSpan)
        {
            Core.StringSet(key, JsonConvert.SerializeObject(value), expireSpan, When.Always, CommandFlags.FireAndForget);
        }

        public void SetExpireSpan(string key, TimeSpan expireSpan)
        {
            Core.KeyExpire(key, expireSpan, CommandFlags.FireAndForget);
        }

        public void RemoveExpireSpan(string key)
        {
            Core.KeyPersist(key, CommandFlags.FireAndForget);
        }
    }
}
