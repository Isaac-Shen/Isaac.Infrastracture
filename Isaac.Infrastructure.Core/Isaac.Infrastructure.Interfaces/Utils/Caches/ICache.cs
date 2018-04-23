using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Isaac.Infrastructure.Interfaces.Utils.Caches
{
    /// <summary>
    /// 缓存接口
    /// </summary>
    public interface ICache
    {
        /// <summary>
        /// 更新或者添加
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="value">内容</param>
        /// <param name="expireTime">过期时间长度</param>
        void UpdateOrAdd(string key, object value, TimeSpan expireTime);

        /// <summary>
        /// 更新或添加
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="value">内容</param>
        void UpdateOrAdd(string key, object value);

        /// <summary>
        /// 获取键值所代表内容
        /// </summary>
        /// <typeparam name="T">内容泛型类型</typeparam>
        /// <param name="key">键值</param>
        /// <returns>内容对象</returns>
        T GetValue<T>(string key);

        /// <summary>
        /// 获取键值包含内容
        /// </summary>
        /// <param name="key">键值</param>
        /// <returns>内容对象</returns>
        object GetValue(string key);

        /// <summary>
        /// 删除某个键值及其包含的内容
        /// </summary>
        /// <param name="key">键值</param>
        void RemoveKey(string key);

        /// <summary>
        /// 是否包含某个键值
        /// </summary>
        /// <param name="key">键值</param>
        /// <returns>是否包含</returns>
        bool ContainsKey(string key);

        /// <summary>
        /// 搜索符合某个正则表达式的键值
        /// </summary>
        /// <param name="keyPattern">键值正则表达式</param>
        /// <returns>符合要求的键值列表</returns>
        List<string> SearchKeys(Regex keyPattern);

        /// <summary>
        /// 缓存链接对象销毁
        /// </summary>
        void Dispose();

        /// <summary>
        /// 对缓存数据进行持久化
        /// </summary>
        void Save();

        /// <summary>
        /// (可异步)对缓存数据进行持久化
        /// </summary>
        /// <returns>异步任务</returns>
        Task SaveAsync();
    }
}
