using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiciiPubliceBackend.DAL;
using ServiciiPubliceBackend.Models;
using System.Threading.Tasks;
using Serilog;
using ServiciiPubliceBackend.Loggers;

namespace ServiciiPubliceBackend.Repositories
{
    public class BonRepository : IBonRepository
    {
        private readonly AppDbContext _dbContext;

        public BonRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<IEnumerable<Bon>> GetAllAsync()
        {
            Hangfire.BackgroundJob.Enqueue(() => Logger.LogInformation("Requesting all bonuri..."));
            return await _dbContext.Bon.ToListAsync();
        }

        public async Task<IEnumerable<Bon>> GetAllByGhiseuIdAsync(int IdGhiseu)
        {
            Hangfire.BackgroundJob.Enqueue(() => Logger.LogInformation($"Requesting all bonuri with ghiseu id {IdGhiseu}..."));
            return await _dbContext.Bon.Where(b => b.IdGhiseu == IdGhiseu).ToListAsync();
        }

        public async Task<int> AddAsync(Bon bon)
        {
            Hangfire.BackgroundJob.Enqueue(() => Logger.LogInformation("Creating bon..."));
            _dbContext.Bon.Add(bon);
            await _dbContext.SaveChangesAsync();

            Hangfire.BackgroundJob.Enqueue(() => Logger.LogInformation($"Bon created with id {bon.Id}"));
            return bon.Id;
        }

        public async Task<bool> MarkBonAsInProgressAsync(int id)
        {
            Hangfire.BackgroundJob.Enqueue(() => Logger.LogInformation($"Marked bon with id {id} as in progress (in asteptare)"));
            var bon = await _dbContext.Bon.FindAsync(id);
            if (bon == null) return false;

            bon.Stare = "in asteptare";
            bon.ModifiedAt = DateTime.Now;

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> MarkBonAsRecievedAsync(int id)
        {
            Hangfire.BackgroundJob.Enqueue(() => Logger.LogInformation($"Marked bon with id {id} as received (preluat)"));
            var bon = await _dbContext.Bon.FindAsync(id);
            if (bon == null) return false;

            bon.Stare = "preluat";
            bon.ModifiedAt = DateTime.Now;

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> MarkBonAsClosedAsync(int id)
        {
            Hangfire.BackgroundJob.Enqueue(() => Logger.LogInformation($"Marked bon with id {id} as closed (inchis)"));
            var bon = await _dbContext.Bon.FindAsync(id);
            if (bon == null) return false;

            bon.Stare = "inchis";
            bon.ModifiedAt = DateTime.Now;

            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
