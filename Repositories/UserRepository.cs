using Microsoft.EntityFrameworkCore;
using ServiciiPubliceBackend.DAL;
using ServiciiPubliceBackend.DTOs;
using ServiciiPubliceBackend.Models;

namespace ServiciiPubliceBackend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(AppDbContext appDbContext, ILogger<UserRepository> logger)
        {
            _dbContext = appDbContext;
            _logger = logger;
        }

        public async Task<bool> AddUserAsync(User user) 
        {
            _logger.LogInformation("Creating user to database...");
            _dbContext.Users.Add(user);
            _logger.LogInformation("User created!");
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<string> Login(CreateUserDTO userDTO)
        {
            _logger.LogInformation("Logging user...");
            var role = await _dbContext.Users
                .Where(u => u.Username == userDTO.Username && u.Password == userDTO.Password)
                .Select(u => u.Role)
                .FirstOrDefaultAsync();

            _logger.LogInformation("User logged in!");
            return role!;
        }
    }
}
