using Dapper;
using invoice_xlsm_exporter_v3.Data.Abstract;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invoice_xlsm_exporter_v3.Data
{
    public class DapperHelper : IDapperHelper
    {
        private readonly string connectString = string.Empty;

        private IDbConnection _dbConnection;

        public DapperHelper(IConfiguration configuration)
        {
            connectString = configuration.GetConnectionString("invoice-xlsm-exporterConnection");
            _dbConnection = new SqlConnection(connectString);
        }

        public async Task ExcuteNoReturn(string query, DynamicParameters parameters = null, IDbTransaction dbTransaction = null)
        {
            using (var dbConnection = new SqlConnection(connectString))
            {
                await dbConnection.ExecuteAsync(query, parameters, dbTransaction, commandType: CommandType.Text);   
            }
        }

        public async Task<T> ExecureReturn<T>(string query, DynamicParameters parameters = null, IDbTransaction dbTransaction = null)
        {
            using (var dbConnection = new SqlConnection(connectString))
            {
                //diff from video
                return (T)Convert.ChangeType(await dbConnection.ExecuteScalarAsync<T>(query, parameters, dbTransaction, commandType: CommandType.Text), typeof(T));
            }
        }

        public async Task<IEnumerable<T>> ExcuteSqlReturnList<T>(string query, DynamicParameters parameters = null, IDbTransaction dbTransaction = null)
        {
            using (var dbConnection = new SqlConnection(connectString))
            {
                return await dbConnection.QueryAsync<T>(query, parameters, dbTransaction, commandType: CommandType.Text);
            }
        }

        public async Task<IEnumerable<T>> ExcuteStoreProcedureReturnList<T>(string query, DynamicParameters parameters = null, IDbTransaction dbTransaction = null)
        {
            using (var dbConnection = new SqlConnection(connectString))
            {
                return await dbConnection.QueryAsync<T>(query, parameters, dbTransaction, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
