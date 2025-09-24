using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiciiPubliceBackend.DAL;
using ServiciiPubliceBackend.Models;
using System.Threading.Tasks;

namespace ServiciiPubliceBackend.Repositories
{
    public class BonRepository : IBonRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<BonRepository> _logger;

        public BonRepository(AppDbContext appDbContext, ILogger<BonRepository> logger)
        {
            _dbContext = appDbContext;
            _logger = logger;
        }

        public async Task<IEnumerable<Bon>> GetAllAsync()
        {
            _logger.LogInformation("Requesting all bonuri...");
            return await _dbContext.Bon.ToListAsync();
        }

        public async Task<IEnumerable<Bon>> GetAllByGhiseuIdAsync(int IdGhiseu)
        {
            _logger.LogInformation($"Requesting all bonuri with ghiseu id {IdGhiseu}...");
            return await _dbContext.Bon.Where(b => b.IdGhiseu == IdGhiseu).ToListAsync();
        }

        public async Task<int> AddAsync(Bon bon)
        {
            _logger.LogInformation("Creating bon...");
            _dbContext.Bon.Add(bon);
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation($"Bon created with id {bon.Id}");
            return bon.Id;
        }

        public async Task<bool> MarkBonAsInProgressAsync(int id)
        {
            _logger.LogInformation($"Marked bon with id {id} as in progress (in asteptare)");
            var bon = await _dbContext.Bon.FindAsync(id);
            if (bon == null) return false;

            bon.Stare = "in asteptare";
            bon.ModifiedAt = DateTime.Now;

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> MarkBonAsRecievedAsync(int id)
        {
            _logger.LogInformation($"Marked bon with id {id} as received (preluat)");
            var bon = await _dbContext.Bon.FindAsync(id);
            if (bon == null) return false;

            bon.Stare = "preluat";
            bon.ModifiedAt = DateTime.Now;

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> MarkBonAsClosedAsync(int id)
        {
            _logger.LogInformation($"Marked bon with id {id} as closed (inchis)");
            var bon = await _dbContext.Bon.FindAsync(id);
            if (bon == null) return false;

            bon.Stare = "inchis";
            bon.ModifiedAt = DateTime.Now;

            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
