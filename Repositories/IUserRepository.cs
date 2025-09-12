using ServiciiPubliceBackend.Models;

namespace ServiciiPubliceBackend.Repositories
{
    public interface IUserRepository
    {
        Task<bool> AddUserAsync(User user);
    }
}
