using ServiciiPubliceBackend.Models;

namespace ServiciiPubliceBackend.Repositories
{
    public interface IGhiseuRepository
    {
        Task<IEnumerable<Ghiseu>> GetAllGhiseuAsync();
        Task<bool> EditGhiseuAsync(Ghiseu ghiseuNou);
        Task<bool> MarkGhiseuAsActiveAsync(int Id);
        Task<bool> MarkGhiseuAsInactiveAsync(int Id);
        Task<bool> DeleteGhiseuAsync(int Id);
    }
}