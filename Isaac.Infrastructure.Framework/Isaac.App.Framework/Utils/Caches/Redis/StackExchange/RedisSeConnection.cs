using Isaac.Infrastructure.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Isaac.App.Framework.Utils
{
    public class RedisSeConnection : IRedisConnection<ConnectionMultiplexer>
    {
        public ConnectionMultiplexer Connect()
        {
            throw new NotImplementedException();
        }

        public void Initialize(string connectionString)
        {
            throw new NotImplementedException();
        }
    }
}
