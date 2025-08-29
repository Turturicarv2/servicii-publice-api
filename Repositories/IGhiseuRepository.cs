using ServiciiPubliceBackend.Models;

namespace ServiciiPubliceBackend.Repositories
{
    public interface IGhiseuRepository
    {
        Task<IEnumerable<Ghiseu>> GetAllGhiseuAsync();
        Task<bool> EditGhiseu(Ghiseu ghiseuNou);
        Task<bool> MarkGhiseuAsActive(int Id);
    }
}