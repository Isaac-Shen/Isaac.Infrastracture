using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.Infrastructure.Framework.Utils
{
    public interface IRedisConnection<T>
    {
        void Initialize(string connectionString);
        T Connect();
    }
}
