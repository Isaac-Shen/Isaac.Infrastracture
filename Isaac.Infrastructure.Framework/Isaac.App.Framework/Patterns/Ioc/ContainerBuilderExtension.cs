using Autofac;
using Autofac.Configuration;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Integration.Mvc;
using CommonServiceLocator;
using Isaac.App.Framework.DataServices;
using Isaac.Infrastructure.Framework.Patterns;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Isaac.App.Framework.Patterns.Ioc
{
    /// <summary>
    /// 容器构造器拓展
    /// </summary>
    public static class ContainerBuilderExtension
    {
        /// <summary>
        /// 加载自定义配置文件(仅支持Json文件)
        /// </summary>
        /// <param name="builder">容器构造器</param>
        /// <param name="fileFullPath">Json配置文件全路径</param>
        /// <returns>容器构造器</returns>
        public static ContainerBuilder LoadCustomModule(this ContainerBuilder builder, string fileFullPath)
        {
            if (File.Exists(fileFullPath))
            {
                try
                {
                    var configBuilder = new ConfigurationBuilder();
                    configBuilder.AddJsonFile(fileFullPath);

                    var customModule = new ConfigurationModule(configBuilder.Build());
                    builder.RegisterModule(customModule);
                }
                catch
                {
                }
            }

            return builder;
        }

        /// <summary>
        /// 加载Mvc控制器
        /// </summary>
        /// <param name="builder">容器构造器</param>
        /// <param name="controllerAssembly">待加载控制器程序集</param>
        /// <returns>容器构造器</returns>
        public static ContainerBuilder LoadMvcController(this ContainerBuilder builder, Assembly controllerAssembly)
        {
            builder.RegisterControllers(controllerAssembly);

            return builder;
        }

        public static ContainerBuilder LoadDatabases(this ContainerBuilder builder, DataService.DatabseType type, List<DataService> services)
        {
            switch (type)
            {
                case DataService.DatabseType.SqlServer:
                    DataService.LoadSqlServerService(builder, services);
                    break;
                case DataService.DatabseType.MySql:
                    DataService.LoadMySqlService(builder, services);
                    break;
                case DataService.DatabseType.Oracle:
                    DataService.LoadOracleService(builder, services);
                    break;
                default:
                    throw new NotImplementedException();
            }
            return builder;
        }

        /// <summary>
        /// 记载DAL数据访问层
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="daoAssembly">待加载DAO程序集</param>
        /// <returns></returns>
        public static ContainerBuilder LoadDaos(this ContainerBuilder builder, Assembly daoAssembly)
        {
            builder.RegisterAssemblyTypes(daoAssembly)
                   .Where(t => t.Name.EndsWith("Dao"));

            return builder;
        }

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
