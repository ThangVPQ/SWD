using invoice_xlsm_exporter_v3.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace invoice_xlsm_exporter_v3.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        InvoiceXlsmExportexContext _invoiceXlsmExporterContext;


        public Repository(InvoiceXlsmExportexContext invoiceXlsmExportexContext) {
            _invoiceXlsmExporterContext = invoiceXlsmExportexContext;
        }

        public async Task<IEnumerable<T>> GetData(Expression<Func<T, bool>> expression = null)
        {
            if (expression == null)
            {
                return await _invoiceXlsmExporterContext.Set<T>().ToListAsync();

            }
            return await _invoiceXlsmExporterContext.Set<T>().Where(expression).ToListAsync();

        }
        public async Task<T> GetById(object id)
        {
            return await _invoiceXlsmExporterContext.Set<T>().FindAsync(id);
        }

        public async Task Insert(IEnumerable<T> entities)
        {
            await _invoiceXlsmExporterContext.Set<T>().AddRangeAsync(entities);
            
        }

        public async Task Insert(T entity)  
        {
            await _invoiceXlsmExporterContext.Set<T>().AddAsync(entity);
            
        }

        public void Update(T entity)
        {
            EntityEntry entityEntry = _invoiceXlsmExporterContext.Entry<T>(entity);
            entityEntry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(T entity)
        {
            EntityEntry entityEntry = _invoiceXlsmExporterContext.Entry<T>(entity);
            entityEntry.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public void Delete(Expression<Func<T, bool>> expression)
        {
            var entities = _invoiceXlsmExporterContext.Set<T>().Where(expression).ToList();
            if (entities.Count> 0)
            {
                _invoiceXlsmExporterContext.Set<T>().RemoveRange(entities);
            }
        }

        public virtual IQueryable<T> Table => _invoiceXlsmExporterContext.Set<T>();

        public async Task Commit()
        {
            await _invoiceXlsmExporterContext.SaveChangesAsync();
        }

    }
}
