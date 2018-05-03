using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.Infrastructure.Framework.Patterns
{
    /// <summary>
    /// 全局静态单例引用句柄
    /// </summary>
    public class GlobalHandle<T> : IDisposable
        where T : class, IDisposable
    {
        private readonly T _realRefered;

        public GlobalHandle(T refered)
        {
            _realRefered = refered;
        }

        /// <summary>
        /// 销毁容器引用
        /// </summary>
        public void Dispose()
        {
            _currentRef = null;

            if (_realRefered != null)
            {
                _realRefered.Dispose();
            }
        }

        /// <summary>
        /// 初始化全局引用
        /// </summary>
        /// <param name="refered">被引用</param>
        public static void Initialize(T refered)
        {
            if (refered == null)
                throw new ArgumentNullException("Refered");

            lock (_sychro)
            {
                if (_currentRef == null)
                    _currentRef = new GlobalHandle<T>(refered);
            }
        }

        /// <summary>
        /// 当前容器引用
        /// </summary>
        public static GlobalHandle<T> Current
        {
            get
            {
                if (_currentRef != null)
                    throw new InvalidOperationException("Reference must be intiliazed before any use.");
                else
                    return _currentRef;
            }
        }

        /// <summary>
        /// 获取当前引用
        /// </summary>
        /// <returns>对象容器</returns>
        public static T GetCurrentRef()
        {
            if (_currentRef != null)
                return _currentRef._realRefered;
            else
                return null;
        }

        private static GlobalHandle<T> _currentRef;
        private static readonly object _sychro = new object();
    }
}
