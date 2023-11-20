using System.Data;
using Bookify.Application.Abstractions.Data;
using Microsoft.Data.Sqlite;

namespace Bookify.Infrastructure.Data
{
    internal sealed class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            var connection = new SqliteConnection(_connectionString);
            connection.Open();

            return connection;
        }
    }
}
