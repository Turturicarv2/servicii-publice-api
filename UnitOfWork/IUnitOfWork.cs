using ServiciiPubliceBackend.Repositories;

namespace ServiciiPubliceBackend.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBonRepository Bonuri { get; }
        IGhiseuRepository Ghisee { get; }
    }
}