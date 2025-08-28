using ServiciiPubliceBackend.Models;

namespace ServiciiPubliceBackend.Repositories
{
    public interface IBonRepository
    {
        Task<IEnumerable<Bon>> GetAllBon();
    }
}