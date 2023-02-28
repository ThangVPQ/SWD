using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace invoice_xlsm_exporter_v3.Data.Abstract
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(object id);
        Task Insert(IEnumerable<T> entities);
        Task Insert(T entity);
        void Update(T entity);
        Task<IEnumerable<T>> GetData(Expression<Func<T, bool>> expression = null);
        void Delete (T entity);
        void Delete(Expression<Func<T, bool>> expression);
        Task Commit();


    }
}
