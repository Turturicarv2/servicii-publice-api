using ServiciiPubliceBackend.Repositories;

namespace ServiciiPubliceBackend.UnitOfWork
{
    public interface IUnitOfWork
    {
        BonRepository Bonuri { get; }
        GhiseuRepository Ghisee { get; }
    }
}