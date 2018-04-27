using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.Infrastructure.Framework.Utils
{
    public interface IRdsList
    {
        void Enqueue(string key, object value);

        void Enqueue(string key, object value, TimeSpan expireSpan);

        void EnqueueInverse(string key, object value);

        void EnqueueInverse(string key, object value, TimeSpan expireSpan);

        string Dequeue(string key);

        string DequeueInverse(string key);

        long Length(string key);

        string Get(string key, long index);
    }
}
