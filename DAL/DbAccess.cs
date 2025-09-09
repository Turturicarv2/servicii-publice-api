using Dapper;
using Microsoft.Data.SqlClient;

namespace ServiciiPubliceBackend.DAL
{
    public class DbAccess : IDbAccess
    {
        private readonly string _connectionString;

        public DbAccess(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Default")!;
        }

        public async Task<int> ExecuteNonQueryAsync(string sql, object? parameters = null)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            var result = await connection.ExecuteAsync(sql, parameters);
            connection.Close();
            return result;
        }

        public async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string sql, object? parameters = null)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            return await connection.QueryAsync<T>(sql, parameters);
        }
    }
}
