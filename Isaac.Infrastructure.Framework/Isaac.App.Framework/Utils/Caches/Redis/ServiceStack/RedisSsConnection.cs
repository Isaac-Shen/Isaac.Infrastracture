using Isaac.Infrastructure.Framework.Utils;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.App.Framework.Utils
{
    public class RedisSsConnection : IRedisConnection<IRedisClient>
    {
        public IRedisClient Connect()
        {
            throw new NotImplementedException();
        }

        public void Initialize(string connectionString)
        {
            throw new NotImplementedException();
        }
    }
}
