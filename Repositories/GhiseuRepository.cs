using Microsoft.Data.SqlClient;
using ServiciiPubliceBackend.DAL;
using ServiciiPubliceBackend.Models;

namespace ServiciiPubliceBackend.Repositories
{
    public class GhiseuRepository : IGhiseuRepository
    {
        private readonly IDbAccess _db;

        public GhiseuRepository(IDbAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Ghiseu>> GetAllGhiseuAsync()
        {
            try
            {
                string sql = "SELECT * FROM Ghiseu";
                return await _db.ExecuteQueryAsync<Ghiseu>(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
