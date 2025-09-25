using Hangfire;
using Microsoft.EntityFrameworkCore;
using Serilog;
using ServiciiPubliceBackend.DAL;
using ServiciiPubliceBackend.DTOs;
using ServiciiPubliceBackend.Models;
using ServiciiPubliceBackend.Loggers;

namespace ServiciiPubliceBackend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<bool> AddUserAsync(User user) 
        {
            BackgroundJob.Enqueue(() => Logger.LogInformation("Creating user to database..."));
            _dbContext.Users.Add(user);

            BackgroundJob.Enqueue(() => Logger.LogInformation("User created!"));
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<string> Login(CreateUserDTO userDTO)
        {
            BackgroundJob.Enqueue(() => Logger.LogInformation("Logging user..."));
            var role = await _dbContext.Users
                .Where(u => u.Username == userDTO.Username && u.Password == userDTO.Password)
                .Select(u => u.Role)
                .FirstOrDefaultAsync();

            BackgroundJob.Enqueue(() => Logger.LogInformation("User logged in!"));
            return role!;
        }
    }
}
