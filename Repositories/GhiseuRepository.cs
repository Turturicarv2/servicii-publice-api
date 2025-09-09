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

        public async Task<IEnumerable<Ghiseu>> GetAllAsync()
        {
            string sql = "SELECT * FROM Ghiseu";
            return await _db.ExecuteQueryAsync<Ghiseu>(sql);
        }

        public async Task<int> AddAsync(Ghiseu ghiseuNou)
        {
            string sql = "INSERT INTO Ghiseu " +
                "(Cod, Denumire, Descriere, Icon, Activ) " +
                "OUTPUT INSERTED.Id " +
                "VALUES (@Cod, @Denumire, @Descriere, @Icon, @Activ)";

            var response = await _db.ExecuteQueryAsync<int>(sql, ghiseuNou);
            return response.FirstOrDefault();
        }

        public async Task<bool> EditGhiseuAsync(Ghiseu ghiseuNou)
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

        public async Task<bool> MarkGhiseuAsActiveAsync(int Id)
        {
            string sql = "UPDATE Ghiseu " +
                "SET Activ = 1 " +
                "WHERE Id = @Id";

            var rowsAffected = await _db.ExecuteNonQueryAsync(sql, new { Id });
            return rowsAffected > 0;
        }

        public async Task<bool> MarkGhiseuAsInactiveAsync(int Id)
        {
            string sql = "UPDATE Ghiseu " +
                "SET Activ = 0 " +
                "WHERE Id = @Id";

            var rowsAffected = await _db.ExecuteNonQueryAsync(sql, new { Id });
            return rowsAffected > 0;
        }

        public async Task<bool> DeleteGhiseuAsync(int Id)
        {
            string sql = "DELETE FROM Ghiseu " +
                "WHERE Id = @Id";

            var rowsAffected = await _db.ExecuteNonQueryAsync(sql, new { Id });
            return rowsAffected > 0;
        }
    }
}
