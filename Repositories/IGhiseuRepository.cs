using ServiciiPubliceBackend.Models;

namespace ServiciiPubliceBackend.Repositories
{
    public interface IGhiseuRepository : IBaseRepository<Ghiseu>
    {
        Task<bool> EditGhiseuAsync(Ghiseu ghiseuNou);
        Task<bool> MarkGhiseuAsActiveAsync(int Id);
        Task<bool> MarkGhiseuAsInactiveAsync(int Id);
        Task<bool> DeleteGhiseuAsync(int Id);
    }
}