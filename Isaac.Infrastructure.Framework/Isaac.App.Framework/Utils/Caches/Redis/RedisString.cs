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
        public void AppendStrValue(string key, string value)
        {
            Core.StringAppend(key, value);
        }

        public string GetStrValue(string key)
        {
            return this.GetValue<string>(key);
        }

        /// <summary>
        /// 批量获取键值，存在事务问题，设计时尽量避免多键同时检索
        /// </summary>
        /// <param name="keys">批量键值</param>
        /// <returns>批量结果</returns>
        public List<string> GetStrValues(params string[] keys)
        {
            if (keys != null && keys.Count() > 0)
            {
                List<string> results = new List<string>();

                foreach (var key in keys)
                {
                    if (Core.KeyExists(key))
                        results.Add(this.GetStrValue(key));
                    else
                        continue;
                }

                return results;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 前插内容，效率较低
        /// </summary>
        /// <param name="key">键名</param>
        /// <param name="value">键值</param>
        public void PrependStrValue(string key, string value)
        {
            this.SetStrValue(key, this.GetStrValue(key).Insert(0, value));
        }

        public void SetStrValue(string key, string value)
        {
            this.SetValue(key, value);
        }

        public void SetStrValue(string key, string value, TimeSpan expireSpan)
        {
            this.SetValue(key, value, expireSpan);
        }
    }
}
