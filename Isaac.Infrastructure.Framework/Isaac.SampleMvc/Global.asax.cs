using Autofac;
using Autofac.Configuration;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Integration.Mvc;
using CommonServiceLocator;
using Isaac.App.Framework.Config;
using Isaac.App.Framework.Patterns.Ioc;
using Isaac.App.Framework.Utils.Logs;
using Isaac.Infrastructure.Framework.Patterns;
using Isaac.Infrastructure.Framework.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Isaac.SampleMvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //InfrastructureConfig.SetBundleConfigKey("");
            //InfrastructureConfig.SetIOCConfigKey("");

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            BundleTable.EnableOptimizations = InfrastructureConfig.BUNDLE_OPTIMIZATIONS;

            var builder = new ContainerBuilder();

            var container = builder
                .LoadCustomModule(InfrastructureConfig.IOC_CONFIG_FILE_LOCATION)
                .LoadMvcController(Assembly.GetExecutingAssembly())
                .Build();

            // Service locator模式暂不启用
            container
                .SetDependencyResolver()
                //.SetServiceLocator()
                .GlobalInitialize();

            container.Resolve<ILog>().Information("The application has been successfully started!");
        }

        protected void Application_End()
        {
            GlobalHandle<ILifetimeScope>.GetCurrentRef()
                .Resolve<ILog>().Warning("The application is about to close!");

            GlobalHandle<ILifetimeScope>.Current.Dispose();
        }
    }
}
