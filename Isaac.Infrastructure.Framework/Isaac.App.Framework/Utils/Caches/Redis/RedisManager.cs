using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Isaac.App.Framework.Utils.Caches.Redis
{
    public sealed class RedisManager
    {
        private static ConnectionMultiplexer connection;
        private static string connectionString;

        public static void Initialize(string connectionStr)
        {
            connectionString = connectionStr;
        }

        public static void Initialize(Func<string> getConnection = null)
        {
            if (getConnection == null)
            {
                getConnection = () =>
                {
                    if (ConfigurationManager.AppSettings.HasKeys() && 
                    ConfigurationManager.AppSettings.AllKeys.Contains("CacheDomain"))
                    {
                        return ConfigurationManager.AppSettings["CacheDomain"];
                    }
                    else
                    {
                        throw new Exception("Default action is activated but there is no config!");
                    }
                };
            }

            connectionString = getConnection();
        }

        public static ConnectionMultiplexer GetConnection()
        {
            if (connection == null)
            {
                CreateConnection();
            }

            return connection;
        }

        public static IDatabase GetClient(int dbId = -1, object asyncState = null)
        {
            if (connection == null)
            {
                CreateConnection();
            }

            return connection.GetDatabase(dbId, asyncState);
        }

        public static void CreateConnection()
        {
            connection = ConnectionMultiplexer.Connect(connectionString);
        }
    }
}
