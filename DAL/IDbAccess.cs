
namespace ServiciiPubliceBackend.DAL
{
    public interface IDbAccess
    {
        Task ExecuteNonQueryAsync(string sql, object? parameters = null);
    }
}