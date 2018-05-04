using Autofac;
using Autofac.Core;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Integration.Mvc;
using CommonServiceLocator;
using Isaac.Infrastructure.Framework.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Isaac.App.Framework.Patterns.Ioc
{
    /// <summary>
    /// 容器拓展
    /// </summary>
    public static class ContainerExtension
    {
        /// <summary>
        /// 设置服务定位
        /// </summary>
        /// <param name="container">容器</param>
        /// <returns>容器</returns>
        public static IContainer SetServiceLocator(this IContainer container)
        {
            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));

            return container;
        }

        /// <summary>
        /// 设置依赖解析器
        /// </summary>
        /// <param name="container">容器</param>
        /// <returns>依赖解析器</returns>
        public static AutofacDependencyResolver SetDependencyResolver(this IContainer container)
        {
            var resolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(resolver);

            return resolver;
        }

        /// <summary>
        /// 全局句柄初始化
        /// </summary>
        /// <param name="resolver">解析器</param>
        public static ILifetimeScope GlobalInitialize(this AutofacDependencyResolver resolver)
        {
            GlobalHandle<ILifetimeScope>.Initialize(resolver.RequestLifetimeScope);

            return GlobalHandle<ILifetimeScope>.GetCurrentRef();
        }
    }
}
