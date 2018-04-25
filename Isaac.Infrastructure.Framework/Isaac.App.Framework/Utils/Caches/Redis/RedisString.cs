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
        /// <summary>
        /// 在指定键值后添加内容
        /// </summary>
        /// <param name="key">键名</param>
        /// <param name="value">待添加键值</param>
        public void AppendStrValue(string key, string value)
        {
            Core.StringAppend(key, value);
        }

        /// <summary>
        /// 获取字符串内容
        /// </summary>
        /// <param name="key">键名</param>
        /// <returns>字符串键值</returns>
        public string GetStrValue(string key)
        {
            return this.GetValue<string>(key);
        }

        /// <summary>
        /// 批量获取字符串键值，存在事务问题，设计时尽量避免多键同时检索
        /// </summary>
        /// <param name="keys">批量键值</param>
        /// <returns>批量结果</returns>
        public IEnumerable<string> GetStrValues(params string[] keys)
        {
            if (keys != null && keys.Count() > 0)
            {
                return Core.StringGet(keys.OfType<RedisKey>().ToArray()).OfType<string>();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 前插字符串内容，效率较低
        /// </summary>
        /// <param name="key">键名</param>
        /// <param name="value">键值</param>
        public void PrependStrValue(string key, string value)
        {
            this.SetStrValue(key, this.GetStrValue(key).Insert(0, value));
        }

        /// <summary>
        /// 设置字符串内容
        /// </summary>
        /// <param name="key">键名</param>
        /// <param name="value">键值</param>
        public void SetStrValue(string key, string value)
        {
            this.SetValue(key, value);
        }

        /// <summary>
        /// 设置字符串内容
        /// </summary>
        /// <param name="key">键名</param>
        /// <param name="value">键值</param>
        /// <param name="expireSpan">过期时间</param>
        public void SetStrValue(string key, string value, TimeSpan expireSpan)
        {
            this.SetValue(key, value, expireSpan);
        }
    }
}
