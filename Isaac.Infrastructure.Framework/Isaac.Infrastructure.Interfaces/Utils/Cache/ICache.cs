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
        bool ContainsKey(string Key);
        T GetValue<T>(string Key);
        void SetValue(string Key, object Value);
        void SetValue(string Key, object Value, TimeSpan ExpireSpan);
        void RemoveKey(string Key);
        void Save();
        Task SaveAsync();
    }
}
