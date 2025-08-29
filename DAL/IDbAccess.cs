
namespace ServiciiPubliceBackend.DAL
{
    public interface IDbAccess
    {
        Task ExecuteNonQueryAsync(string sql, object? parameters = null);
        Task<IEnumerable<T>> ExecuteQueryAsync<T> (string sql, object? parameters = null);
    }
}