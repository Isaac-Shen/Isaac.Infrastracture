using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.Infrastructure.Framework.Utils
{
    public interface IRdsString
    {
        string GetStrValue(string Key);

        IEnumerable<string> GetStrValues(IEnumerable<string> keys);

        void SetStrValue(string Key, string Value);

        void SetStrValue(string Key, string Value, TimeSpan ExpireSpan);

        void AppendStrValue(string key, string Value);

        void PrependStrValue(string key, string Value);
    }
}
