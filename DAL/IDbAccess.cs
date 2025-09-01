
namespace ServiciiPubliceBackend.DAL
{
    public interface IDbAccess
    {
        Task<int> ExecuteNonQueryAsync(string sql, object? parameters = null);
        Task<IEnumerable<T>> ExecuteQueryAsync<T> (string sql, object? parameters = null);
    }
}