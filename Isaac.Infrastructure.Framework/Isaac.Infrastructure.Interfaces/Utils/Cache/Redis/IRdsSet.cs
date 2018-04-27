using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.Infrastructure.Framework.Utils
{
    public interface IRdsSet
    {
        void Add(string key, object value);

        IEnumerable<string> CombineUnion(string firstKey, string secondKey);

        IEnumerable<string> CombineIntersect(string firstKey, string secondKey);

        IEnumerable<string> CombineDifference(string firstKey, string secondKey);

        bool Contains(string key, object value);

        string RandomElement(string key);

        string Pop(string key);

        long Length(string key);

        void Move(string srcKey, string destKey, object value);

        IEnumerable<string> AllMembers(string key);

        void Remove(string key, object value); 


    }
}
