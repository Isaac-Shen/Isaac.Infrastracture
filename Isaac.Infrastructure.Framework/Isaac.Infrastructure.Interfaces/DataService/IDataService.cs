using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.Infrastructure.Framework.DataService
{
    public interface IDataService<T>
        where T : class
    {
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int Insert(T t);

        /// <summary>
        /// 批量添加记录
        /// </summary>
        /// <param name="t"></param>
        /// <exception cref="DataException"></exception>
        void Insert(IEnumerable<T> t);

        /// <summary>
        /// 更新新记录
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Update(T t);

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Delete(T t);

        /// <summary>
        /// 查找记录
        /// </summary>
        /// <typeparam name="TId"></typeparam>
        /// <param name="id"></param>
        /// <param name="useMasterDb"></param>
        /// <returns></returns>
        T FindBy<TId>(TId id, bool useMasterDb = false);
    }
}
