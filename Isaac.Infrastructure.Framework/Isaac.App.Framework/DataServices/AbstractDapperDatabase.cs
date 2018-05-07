using DapperExtensions;
using DapperExtensions.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.App.Framework.DataServices
{
    public class AbstractDapperDatabase : Database, IDatabase
    {
        public AbstractDapperDatabase(IDbConnection connection, ISqlGenerator sqlGenerator)
            : base(connection, sqlGenerator)
        {
        }

        public new void Dispose()
        {
            using (Connection)
            {
                Connection.Dispose();
                base.Dispose();
            }
        }
    }
}
