using ValidataShopping.Application.SeedWork;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ValidataShopping.Infrastructure.SqlServer.SeedWork
{
    public class SqlConnectionFactory : ISqlConnectionFactory, IDisposable
    {
        private IDbConnection _dbConnection;
        private string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Dispose()
        {
            if (_dbConnection != null && _dbConnection.State == ConnectionState.Open)
            {
                _dbConnection.Dispose();
            }
        }

        public IDbConnection GetOpenConnection()
        {
            if (_dbConnection == null || _dbConnection.State != ConnectionState.Open)
            {
                _dbConnection = new SqlConnection(_connectionString);
                _dbConnection.Open();
            }

            return _dbConnection;
        }
    }
}
