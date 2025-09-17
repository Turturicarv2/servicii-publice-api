using Microsoft.EntityFrameworkCore;
using ServiciiPubliceBackend.DAL;
using ServiciiPubliceBackend.DTOs;
using ServiciiPubliceBackend.Models;

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
            _dbContext.Users.Add(user);
            return await _dbContext.SaveChangesAsync() > 0;
        }
        public async Task<string> Login(CreateUserDTO userDTO)
        {
            var role = await _dbContext.Users
                .Where(u => u.Username == userDTO.Username && u.Password == userDTO.Password)
                .Select(u => u.Role)
                .FirstOrDefaultAsync();

            return role!;
        }
    }
}
