using Autofac;
using Autofac.Extras.DynamicProxy2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.App.Framework.Utils.InitialLoad
{
    public class InitialLoad
    {
        public static void Load(ContainerBuilder builder, params Type[] types)
        {
            foreach (var item in types)
            {
                builder.RegisterType(item);
            }

            var sth = builder.RegisterType<LoadSuccess>().As<ILoadSuccess>();

            foreach (var item in types)
            {
                sth = sth.InterceptedBy(item);
            }

            sth.EnableInterfaceInterceptors();
        }
    }
}
