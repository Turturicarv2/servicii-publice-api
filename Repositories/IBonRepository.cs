using ServiciiPubliceBackend.Models;

namespace ServiciiPubliceBackend.Repositories
{
    public interface IBonRepository : IBaseRepository<Bon>
    {
        Task<IEnumerable<Bon>> GetAllByGhiseuIdAsync(int IdGhiseu);
        Task<bool> MarkBonAsInProgressAsync(int id);
        Task<bool> MarkBonAsRecievedAsync(int id);
        Task<bool> MarkBonAsClosedAsync(int id);
    }
}