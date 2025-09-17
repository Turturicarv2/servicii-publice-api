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

        public BonRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<IEnumerable<Bon>> GetAllAsync()
        {
            return await _dbContext.Bon.ToListAsync();
        }

        public async Task<IEnumerable<Bon>> GetAllByGhiseuIdAsync(int IdGhiseu)
        {
            return await _dbContext.Bon.Where(b => b.IdGhiseu == IdGhiseu).ToListAsync();
        }

        public async Task<int> AddAsync(Bon bon)
        {
            _dbContext.Bon.Add(bon);
            await _dbContext.SaveChangesAsync();
            return bon.Id;
        }

        public async Task<bool> MarkBonAsInProgressAsync(int id)
        {
            var bon = await _dbContext.Bon.FindAsync(id);
            if (bon == null) return false;

            bon.Stare = "in asteptare";
            bon.ModifiedAt = DateTime.Now;

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> MarkBonAsRecievedAsync(int id)
        {
            var bon = await _dbContext.Bon.FindAsync(id);
            if (bon == null) return false;

            bon.Stare = "preluat";
            bon.ModifiedAt = DateTime.Now;

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> MarkBonAsClosedAsync(int id)
        {
            var bon = await _dbContext.Bon.FindAsync(id);
            if (bon == null) return false;

            bon.Stare = "inchis";
            bon.ModifiedAt = DateTime.Now;

            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
