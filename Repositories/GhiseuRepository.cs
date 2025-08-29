using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
                throw;
            }
        }

        public async Task<bool> EditGhiseu(Ghiseu ghiseuNou)
        {
            if (ghiseuNou == null)
            {
                throw new ArgumentNullException(nameof(ghiseuNou));
            }

            string sql = "UPDATE Ghiseu " +
                "SET Cod = @Cod, " +
                "Denumire = @Denumire, " +
                "Descriere = @Descriere, " +
                "Icon = @Icon " +
                "WHERE Id = @Id";

            var rowsAffected = await _db.ExecuteNonQueryAsync(sql, ghiseuNou);

            return rowsAffected > 0;
        }

        public async Task<bool> MarkGhiseuAsActive(int Id)
        {
            string sql = "UPDATE Ghiseu " +
                "SET Activ = 1 " +
                "WHERE Id = @Id";

            var rowsAffected = await _db.ExecuteNonQueryAsync(sql, new { Id });
            return rowsAffected > 0;
        }
    }
}
