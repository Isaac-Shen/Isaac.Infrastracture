using Isaac.Infrastructure.Framework.Utils;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.App.Framework.Utils.Caches.Redis.StackExchange
{
    public class RedisSeManager : IRedisManager<ConnectionMultiplexer>
    {
        private static ConnectionMultiplexer _client;

        public ConnectionMultiplexer GetClient()
        {
            return _client;
        }

        public void Initialize(IRedisConnection<ConnectionMultiplexer> connection)
        {
            if (connection != null)
            {
                _client = connection.Connect();
            }
        }
    }
}
