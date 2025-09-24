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
        private readonly ILogger<BonRepository> _logger;

        public GhiseuRepository(AppDbContext appDbContext, ILogger<BonRepository> logger)
        {
            _dbContext = appDbContext;
            _logger = logger;
        }

        public async Task<IEnumerable<Ghiseu>> GetAllAsync()
        {
            _logger.LogInformation("Requesting all ghisee...");
            return await _dbContext.Ghiseu.ToListAsync();
        }

        public async Task<int> AddAsync(Ghiseu ghiseuNou)
        {
            _logger.LogInformation("Creating ghiseu...");
            _dbContext.Add(ghiseuNou);
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation($"Ghiseu created with id {ghiseuNou.Id}");
            return ghiseuNou.Id;
        }

        public async Task<bool> EditGhiseuAsync(Ghiseu ghiseuNou)
        {
            _logger.LogInformation("Updating ghiseu...");
            if (ghiseuNou == null)
            {
                _logger.LogError("Ghiseu is null!");
                throw new ArgumentNullException(nameof(ghiseuNou));
            }

            var existing = await _dbContext.Ghiseu.FindAsync(ghiseuNou.Id);
            if (existing == null)
            {
                _logger.LogError("Ghiseu doesn't exist!");
                return false; 
            }

            existing.Cod = ghiseuNou.Cod;
            existing.Denumire = ghiseuNou.Denumire;
            existing.Descriere = ghiseuNou.Descriere;
            existing.Icon = ghiseuNou.Icon;

            _logger.LogInformation("Ghiseu Updated!");
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> MarkGhiseuAsActiveAsync(int Id)
        {
            _logger.LogInformation("Marking ghiseu as active...");
            var ghiseu = await _dbContext.Ghiseu.FindAsync(Id);
            if (ghiseu == null)
                return false;

            ghiseu.Activ = true;

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> MarkGhiseuAsInactiveAsync(int Id)
        {
            _logger.LogInformation("Marking ghiseu as inactive...");
            var ghiseu = await _dbContext.Ghiseu.FindAsync(Id);
            if (ghiseu == null)
                return false;

            ghiseu.Activ = false;

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteGhiseuAsync(int Id)
        {
            _logger.LogInformation($"Deleting ghiseu with id {Id}...");
            var ghiseu = await _dbContext.Ghiseu.FindAsync(Id);
            if (ghiseu == null)
                return false;

            _dbContext.Remove(ghiseu);
            _logger.LogInformation("Ghiseu deleted!");
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
