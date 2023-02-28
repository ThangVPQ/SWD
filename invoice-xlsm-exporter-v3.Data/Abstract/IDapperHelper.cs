using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invoice_xlsm_exporter_v3.Data.Abstract
{
    public interface IDapperHelper
    {
        Task ExcuteNoReturn(string query, DynamicParameters parameters = null, IDbTransaction dbTransaction = null);

        Task<T> ExecureReturn<T>(string query, DynamicParameters parameters = null, IDbTransaction dbTransaction = null);


        Task<IEnumerable<T>> ExcuteSqlReturnList<T>(string query, DynamicParameters parameters = null, IDbTransaction dbTransaction = null);

        Task<IEnumerable<T>> ExcuteStoreProcedureReturnList<T>(string query, DynamicParameters parameters = null, IDbTransaction dbTransaction = null);
    }
}
