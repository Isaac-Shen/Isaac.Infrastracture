using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Integration.Mvc;
using CommonServiceLocator;
using Isaac.Infrastructure.Framework.Patterns;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DetermineMode();
            IocConfiguration();
        }

        protected void Application_End()
        {
            GlobalHandle<ILifetimeScope>.Current.Dispose();
        }

        protected void IocConfiguration()
        {
            var builder = new ContainerBuilder();

            var container = builder.Build();

            #region Set service locator
            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));
            #endregion

            #region Set resolver for MVC
            var resolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(resolver);
            GlobalHandle<ILifetimeScope>.Initialize(resolver.RequestLifetimeScope);
            #endregion
        }

        protected void DetermineMode()
        {
            string bundleConfig = "bundle:Optimizations";
            if (ConfigurationManager.AppSettings.AllKeys.Contains(bundleConfig))
            {
                bool result = false;
                if (Boolean.TryParse(ConfigurationManager.AppSettings[bundleConfig], out result))
                {
                    BundleTable.EnableOptimizations = result;
                }

                return;
            }

            BundleTable.EnableOptimizations = true;
        }
    }
}
