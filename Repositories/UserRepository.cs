using ServiciiPubliceBackend.DAL;
using ServiciiPubliceBackend.DbQueries;
using ServiciiPubliceBackend.DTOs;
using ServiciiPubliceBackend.Models;

namespace ServiciiPubliceBackend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbAccess _db;
        private readonly UserQueryManager _queryManager;
        public UserRepository(IDbAccess db) 
        {
            _queryManager = new UserQueryManager();
            _db = db;
        }
        public async Task<bool> AddUserAsync(User user) 
        {
            string sql = _queryManager.addUserQuery;

            var rowsAffected = await _db.ExecuteNonQueryAsync(sql, user);
            return rowsAffected > 0;
        }
        public async Task<string> Login(CreateUserDTO userDTO)
        {
            string sql = _queryManager.loginUserQuery;

            var result = await _db.ExecuteQueryAsync<string>(sql, userDTO);
            return result.FirstOrDefault()!;
        }
    }
}
