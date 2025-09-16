using ServiciiPubliceBackend.Repositories;
using ServiciiPubliceBackend.TokenManagers;

namespace ServiciiPubliceBackend.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBonRepository Bonuri { get; }
        IGhiseuRepository Ghisee { get; }
        IUserRepository Users { get; }
        ITokenManager TokenManager { get; }
    }
}