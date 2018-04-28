using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Integration.Mvc;
using Isaac.Infrastructure.Framework.Patterns;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Isaac.App.Framework.Patterns.Ioc
{
    public class AutoFacContainer
    {
        public static ContainerBuilder GetBuilder()
        {
            return new ContainerBuilder();
        }

        public static ILifetimeScope GetContainer(ContainerBuilder builder)
        {
            IContainer container = builder.Build();
            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));
            var autofacDependencyResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(autofacDependencyResolver);
            GlobalHandle<ILifetimeScope>.Initialize(autofacDependencyResolver.ApplicationContainer);

            return GlobalHandle<ILifetimeScope>.GetCurrentRef();
        }
    }
}
