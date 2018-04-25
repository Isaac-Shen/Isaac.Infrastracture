using Isaac.App.Framework.Utils.Caches.Redis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RedisManager.Initialize("localhost:6379");

            var connect = new RedisString();

            Stopwatch watcher = new Stopwatch();

            string newkey = Guid.NewGuid().ToString();
            int count = 0;
            watcher.Start();
            connect.SetStrValue(newkey, "G");

            while (true)
            {
                count++;
                connect.AppendStrValue(newkey, "G");

                if (connect.GetStrValue(newkey).Length > 10000)
                {
                    watcher.Stop();
                    break;
                }
            }

            Console.WriteLine("Done! Takes {0}ms, R/W operates {1} times", watcher.ElapsedMilliseconds, count*2);
            Console.ReadKey();
        }
    }
}
