using Autofac;
using Autofac.Configuration;
using Autofac.Integration.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
        /// <returns>容器构造器</returns>
        public static ContainerBuilder LoadMvcController(this ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            return builder;
        }
    }
}
