using Microsoft.EntityFrameworkCore;
using ServiciiPubliceBackend.Models;

namespace ServiciiPubliceBackend.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Ghiseu> Ghiseu { get; set; }
        public DbSet<Bon> Bon { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
