using DapperExtensions.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.App.Framework.DataServices
{
    public class IsaacSampleDatabase : AbstractDapperDatabase
    {
        public IsaacSampleDatabase(IDbConnection connection, ISqlGenerator sqlGenerator)
            : base(connection, sqlGenerator)
        { }
    }
}
