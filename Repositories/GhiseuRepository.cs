using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ServiciiPubliceBackend.DAL;
using ServiciiPubliceBackend.Models;

namespace ServiciiPubliceBackend.Repositories
{
    public class GhiseuRepository : IGhiseuRepository
    {
        private readonly AppDbContext _dbContext;

        public GhiseuRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<IEnumerable<Ghiseu>> GetAllAsync()
        {
            return await _dbContext.Ghiseu.ToListAsync();
        }

        public async Task<int> AddAsync(Ghiseu ghiseuNou)
        {
            _dbContext.Add(ghiseuNou);
            await _dbContext.SaveChangesAsync();
            return ghiseuNou.Id;
        }

        public async Task<bool> EditGhiseuAsync(Ghiseu ghiseuNou)
        {
            if (ghiseuNou == null)
            {
                throw new ArgumentNullException(nameof(ghiseuNou));
            }

            var existing = await _dbContext.Ghiseu.FindAsync(ghiseuNou.Id);
            if (existing == null)
            {
                return false; 
            }

            existing.Cod = ghiseuNou.Cod;
            existing.Denumire = ghiseuNou.Denumire;
            existing.Descriere = ghiseuNou.Descriere;
            existing.Icon = ghiseuNou.Icon;

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> MarkGhiseuAsActiveAsync(int Id)
        {
            var ghiseu = await _dbContext.Ghiseu.FindAsync(Id);
            if (ghiseu == null)
                return false;

            ghiseu.Activ = true;

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> MarkGhiseuAsInactiveAsync(int Id)
        {
            var ghiseu = await _dbContext.Ghiseu.FindAsync(Id);
            if (ghiseu == null)
                return false;

            ghiseu.Activ = false;

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteGhiseuAsync(int Id)
        {
            _dbContext.Remove(Id);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
