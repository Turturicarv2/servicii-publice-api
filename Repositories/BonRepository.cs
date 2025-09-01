using Microsoft.AspNetCore.Mvc;
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
            string sql = "INSERT INTO Bon " +
                "(IdGhiseu, Stare, CreatedAt) " +
                "VALUES (@IdGhiseu, @Stare, @CreatedAt)";

            await _db.ExecuteNonQueryAsync(sql, bon);
            return true;
        }

        public async Task<bool> MarkBonAsInProgressAsync(int id)
        {
            string sql = "UPDATE Bon " +
                "SET Stare = @Stare, ModifiedAt = @ModifiedAt " +
                "WHERE Id = @Id";

            await _db.ExecuteNonQueryAsync(sql, new { Id = id, Stare = "in asteptare", ModifiedAt = DateTime.Now });
            return true;
        }

        public async Task<bool> MarkBonAsRecievedAsync(int id)
        {
            string sql = "UPDATE Bon " +
                "SET Stare = @Stare, ModifiedAt = @ModifiedAt " +
                "WHERE Id = @Id";

            await _db.ExecuteNonQueryAsync(sql, new { Id = id, Stare = "preluat", ModifiedAt = DateTime.Now });
            return true;
        }

        public async Task<bool> MarkBonAsClosedAsync(int id)
        {
            string sql = "UPDATE Bon " +
                "SET Stare = @Stare, ModifiedAt = @ModifiedAt " +
                "WHERE Id = @Id";

            await _db.ExecuteNonQueryAsync(sql, new { Id = id, Stare = "inchis", ModifiedAt = DateTime.Now });
            return true;
        }
    }
}
