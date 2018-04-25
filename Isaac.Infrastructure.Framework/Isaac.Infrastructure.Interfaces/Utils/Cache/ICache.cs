using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Isaac.Infrastructure.Framework.Utils
{
    /// <summary>
    /// 通用缓存接口
    /// </summary>
    public interface ICache
    {
        bool ContainsKey(string key);
        T GetValue<T>(string key);
        void SetValue(string key, object value);
        void SetValue(string key, object value, TimeSpan expireSpan);
        void SetExpireSpan(string key, TimeSpan expireSpan);
        void RemoveExpireSpan(string key);
        void RemoveKey(string key);
        void Save();
        Task SaveAsync();
    }
}
