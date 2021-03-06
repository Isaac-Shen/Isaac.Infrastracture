﻿using Autofac;
using DapperExtensions;
using Isaac.App.Framework.DataServices;
using Isaac.Infrastructure.Framework.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.SampleMvc.Dal
{
    public class CommonDao<T> : AbstractDapperDao<T>
        where T : class
    {
        protected override IDatabase Database
        {
            get
            {
                return GlobalHandle<ILifetimeScope>.GetCurrentRef().Resolve<IsaacSampleDatabase>();
            }
        }

        protected string MySqlPagination(string sql, int pageNum, int pageLoad)
        {
            if (pageNum * pageLoad != 0)
            {
                return string.Format("{2} limit {0},{1}", pageNum * (pageLoad - 1), pageNum, sql);
            }

            return sql;
        }
    }
}
