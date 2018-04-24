using Autofac;
using Castle.DynamicProxy;
using Isaac.App.Framework.Utils.Caches.Redis;
using Isaac.App.Framework.Utils.InitialLoad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.App.Framework.Utils.IntialLoad
{
    public class LoadRedis : AbstractLoad<string>
    {
        public LoadRedis(Func<string> action, ContainerBuilder builder)
            : base(action, builder)
        {
            var connection = GetAction.Invoke();
            RedisManager.Initialize(connection);
        }

        public override string DefaultAction()
        {
            if (ConfigurationManager.AppSettings.HasKeys() && 
                ConfigurationManager.AppSettings.AllKeys.Contains("CacheDomain"))
            {
                return ConfigurationManager.AppSettings["CacheDomain"];
            }
            else
            {
                throw new Exception(
                    "Default action is activated but there seems no redis config in your app.config");
            }
        }
    }
}
