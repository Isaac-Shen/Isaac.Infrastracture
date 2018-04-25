using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.Infrastructure.Framework.Utils
{
    public interface IRdsString
    {
        string GetStrValue(string key);

        List<string> GetStrValues(params string[] keys);

        void SetStrValue(string key, string value);

        void SetStrValue(string key, string value, TimeSpan expireSpan);

        void AppendStrValue(string key, string value);

        void PrependStrValue(string key, string value);
    }
}
