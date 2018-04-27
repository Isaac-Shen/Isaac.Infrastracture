using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.Infrastructure.Framework.Utils
{
    public interface IRdsSortedSet
    {
        void ZSetAdd(string key, object value, double score);

        IDictionary<string, double> GetSelectedRange(string key, double cap, double floor, bool isDescending);

        long Length(string key);
    }
}
