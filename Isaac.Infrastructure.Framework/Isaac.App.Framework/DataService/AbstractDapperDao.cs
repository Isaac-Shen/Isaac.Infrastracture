using DapperExtensions;
using Isaac.Infrastructure.Framework.DataService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.App.Framework.DataService
{
    public abstract class AbstractDapperDao<T> : IDataService<T>
        where T : class
    {
        public virtual bool Delete(T t)
        {
            return Database.Delete(t);
        }

        public virtual T FindBy<TId>(TId id, bool useMasterDb = false)
        {
            return Database.Get<T>(id);
        }

        public virtual int Insert(T t)
        {
            return Database.Insert(t);
        }

        public virtual void Insert(IEnumerable<T> t)
        {
            try
            {
                Database.BeginTransaction();
                Database.Insert(t);
                Database.Commit();
            }
            catch (Exception exp)
            {
                Database.Rollback();
                throw new DataException("Batch insert cause some problem", exp);
            }
        }

        public virtual bool Update(T t)
        {
            return Database.Update(t);
        }

        protected abstract IDatabase Database { get; }
    }
}
