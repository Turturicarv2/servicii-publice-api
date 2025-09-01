using ServiciiPubliceBackend.DAL;
using ServiciiPubliceBackend.Models;
using System.Threading.Tasks;

namespace ServiciiPubliceBackend.Repositories
{
    public class BonRepository : IBonRepository
    {
        private readonly IDbAccess _db;

        public BonRepository(IDbAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Bon>> GetAllAsync()
        {
            string sql = "SELECT * FROM Bon";
            return await _db.ExecuteQueryAsync<Bon>(sql);
        }

        public async Task<bool> AddAsync(Bon bon)
        {
            return true;
        }
    }
}
