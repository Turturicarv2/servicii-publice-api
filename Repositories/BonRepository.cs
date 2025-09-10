using Microsoft.AspNetCore.Mvc;
using ServiciiPubliceBackend.DAL;
using ServiciiPubliceBackend.DbQueries;
using ServiciiPubliceBackend.Models;
using System.Threading.Tasks;

namespace ServiciiPubliceBackend.Repositories
{
    public class BonRepository : IBonRepository
    {
        private readonly IDbAccess _db;
        private BonQueryManager _queryManager;

        public BonRepository(IDbAccess db)
        {
            _db = db;
            _queryManager = new BonQueryManager();
        }

        public async Task<IEnumerable<Bon>> GetAllAsync()
        {
            string sql = _queryManager.getAllBonQuery;
            return await _db.ExecuteQueryAsync<Bon>(sql);
        }

        public async Task<IEnumerable<Bon>> GetAllByGhiseuIdAsync(int IdGhiseu)
        {
            string sql = _queryManager.getAllBonByGhiseuIdQuery;
            return await _db.ExecuteQueryAsync<Bon>(sql, new { IdGhiseu });
        }

        public async Task<int> AddAsync(Bon bon)
        {
            string sql = _queryManager.addBonQuery;

            var response = await _db.ExecuteQueryAsync<int>(sql, bon);
            return response.FirstOrDefault();
        }

        public async Task<bool> MarkBonAsInProgressAsync(int id)
        {
            string sql = _queryManager.markBonInProgressQuery;

            await _db.ExecuteNonQueryAsync(sql, new { Id = id, Stare = "in asteptare", ModifiedAt = DateTime.Now });
            return true;
        }

        public async Task<bool> MarkBonAsRecievedAsync(int id)
        {
            string sql = _queryManager.markBonReceivedQuery;

            await _db.ExecuteNonQueryAsync(sql, new { Id = id, Stare = "preluat", ModifiedAt = DateTime.Now });
            return true;
        }

        public async Task<bool> MarkBonAsClosedAsync(int id)
        {
            string sql = _queryManager.markBonClosedQuery;

            await _db.ExecuteNonQueryAsync(sql, new { Id = id, Stare = "inchis", ModifiedAt = DateTime.Now });
            return true;
        }
    }
}
