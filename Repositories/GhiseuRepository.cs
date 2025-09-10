using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ServiciiPubliceBackend.DAL;
using ServiciiPubliceBackend.DbQueries;
using ServiciiPubliceBackend.Models;

namespace ServiciiPubliceBackend.Repositories
{
    public class GhiseuRepository : IGhiseuRepository
    {
        private readonly IDbAccess _db;
        private GhiseuQueryManager _queryManager;

        public GhiseuRepository(IDbAccess db)
        {
            _db = db;
            _queryManager = new GhiseuQueryManager();
        }

        public async Task<IEnumerable<Ghiseu>> GetAllAsync()
        {
            string sql = _queryManager.getAllGhiseeQuery;
            return await _db.ExecuteQueryAsync<Ghiseu>(sql);
        }

        public async Task<int> AddAsync(Ghiseu ghiseuNou)
        {
            string sql = _queryManager.addGhiseuQuery;

            var response = await _db.ExecuteQueryAsync<int>(sql, ghiseuNou);
            return response.FirstOrDefault();
        }

        public async Task<bool> EditGhiseuAsync(Ghiseu ghiseuNou)
        {
            if (ghiseuNou == null)
            {
                throw new ArgumentNullException(nameof(ghiseuNou));
            }

            string sql = _queryManager.editGhiseuQuery;

            var rowsAffected = await _db.ExecuteNonQueryAsync(sql, ghiseuNou);

            return rowsAffected > 0;
        }

        public async Task<bool> MarkGhiseuAsActiveAsync(int Id)
        {
            string sql = _queryManager.markGhiseuActiveQuery;

            var rowsAffected = await _db.ExecuteNonQueryAsync(sql, new { Id });
            return rowsAffected > 0;
        }

        public async Task<bool> MarkGhiseuAsInactiveAsync(int Id)
        {
            string sql = _queryManager.markGhiseuInactiveQuery;

            var rowsAffected = await _db.ExecuteNonQueryAsync(sql, new { Id });
            return rowsAffected > 0;
        }

        public async Task<bool> DeleteGhiseuAsync(int Id)
        {
            string sql = _queryManager.deleteGhiseuQuery;

            var rowsAffected = await _db.ExecuteNonQueryAsync(sql, new { Id });
            return rowsAffected > 0;
        }
    }
}
