using ServiciiPubliceBackend.Models;

namespace ServiciiPubliceBackend.Repositories
{
    public interface IGhiseuRepository
    {
        Task<IEnumerable<Ghiseu>> GetAllGhiseuAsync();
    }
}