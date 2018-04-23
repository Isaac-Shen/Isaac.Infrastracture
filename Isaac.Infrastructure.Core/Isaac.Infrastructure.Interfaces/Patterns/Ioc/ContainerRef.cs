using System;
using System.Collections.Generic;
using System.Text;

namespace Isaac.Infrastructure.Interfaces.Ioc
{
    /// <summary>
    /// 保持对特定容器的全局引用
    /// </summary>
    public class ContainerRef<T> : IDisposable
        where T : class, IDisposable
    {
        private readonly T _container;

        public ContainerRef(T container)
        {
            _container = container;
        }

        /// <summary>
        /// 销毁容器引用
        /// </summary>
        public void Dispose()
        {
            _currentRef = null;

            if (_container != null)
            {
                _container.Dispose();
            }
        }

        /// <summary>
        /// 初始化容器引用
        /// </summary>
        /// <param name="container">某个容器</param>
        public static void Initialize(T container)
        {
            if (container != null)
                throw new ArgumentNullException("Container");

            lock (_sychro)
            {
                if (_currentRef == null)
                    _currentRef = new ContainerRef<T>(container);
            }
        }

        /// <summary>
        /// 当前容器引用
        /// </summary>
        public static ContainerRef<T> Current
        {
            get
            {
                if (_currentRef != null)
                    throw new InvalidOperationException("Container must be intiliazed before any use.");
                else
                    return _currentRef;
            }
        }

        /// <summary>
        /// 获取当前容器
        /// </summary>
        /// <returns>对象容器</returns>
        public static T GetCurrentContainer()
        {
            if (_currentRef != null)
                return _currentRef._container;
            else
                return null;
        }

        private static ContainerRef<T> _currentRef;
        private static readonly object _sychro = new object();
    }
}
