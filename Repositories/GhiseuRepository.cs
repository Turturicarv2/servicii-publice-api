using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ServiciiPubliceBackend.DAL;
using ServiciiPubliceBackend.Models;
using ServiciiPubliceBackend.Loggers;
using Serilog;
using Hangfire;

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
            BackgroundJob.Enqueue(() => Logger.LogInformation("Requesting all ghisee..."));
            return await _dbContext.Ghiseu.ToListAsync();
        }

        public async Task<int> AddAsync(Ghiseu ghiseuNou)
        {
            BackgroundJob.Enqueue(() => Logger.LogInformation("Creating ghiseu..."));
            _dbContext.Add(ghiseuNou);
            await _dbContext.SaveChangesAsync();

            BackgroundJob.Enqueue(() => Logger.LogInformation($"Ghiseu created with id {ghiseuNou.Id}"));
            return ghiseuNou.Id;
        }

        public async Task<bool> EditGhiseuAsync(Ghiseu ghiseuNou)
        {
            BackgroundJob.Enqueue(() => Logger.LogInformation("Updating ghiseu..."));
            if (ghiseuNou == null)
            {
                BackgroundJob.Enqueue(() => Logger.LogError("Ghiseu is null!"));
                throw new ArgumentNullException(nameof(ghiseuNou));
            }

            var existing = await _dbContext.Ghiseu.FindAsync(ghiseuNou.Id);
            if (existing == null)
            {
                BackgroundJob.Enqueue(() => Logger.LogError("Ghiseu doesn't exist!"));
                return false; 
            }

            existing.Cod = ghiseuNou.Cod;
            existing.Denumire = ghiseuNou.Denumire;
            existing.Descriere = ghiseuNou.Descriere;
            existing.Icon = ghiseuNou.Icon;

            BackgroundJob.Enqueue(() => Logger.LogInformation("Ghiseu Updated!"));
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> MarkGhiseuAsActiveAsync(int Id)
        {
            BackgroundJob.Enqueue(() => Logger.LogInformation($"Marking ghiseu with id {Id} as active..."));
            var ghiseu = await _dbContext.Ghiseu.FindAsync(Id);
            if (ghiseu == null)
                return false;

            ghiseu.Activ = true;

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> MarkGhiseuAsInactiveAsync(int Id)
        {
            BackgroundJob.Enqueue(() => Logger.LogInformation($"Marking ghiseu with id {Id} as inactive..."));
            var ghiseu = await _dbContext.Ghiseu.FindAsync(Id);
            if (ghiseu == null)
                return false;

            ghiseu.Activ = false;

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteGhiseuAsync(int Id)
        {
            BackgroundJob.Enqueue(() => Logger.LogInformation($"Deleting ghiseu with id {Id}..."));
            var ghiseu = await _dbContext.Ghiseu.FindAsync(Id);
            if (ghiseu == null)
                return false;

            _dbContext.Remove(ghiseu);
            BackgroundJob.Enqueue(() => Logger.LogInformation("Ghiseu deleted!"));
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
