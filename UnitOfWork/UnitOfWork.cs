using ServiciiPubliceBackend.Repositories;
using ServiciiPubliceBackend.TokenManagers;

namespace ServiciiPubliceBackend.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IGhiseuRepository _ghiseuRepository;
        private readonly IBonRepository _bonRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITokenManager _tokenManager;

        public UnitOfWork(IGhiseuRepository ghiseuRepository, IBonRepository bonRepository, IUserRepository userRepository, ITokenManager tokenManager)
        {
            _ghiseuRepository = ghiseuRepository;
            _bonRepository = bonRepository;
            _userRepository = userRepository;
            _tokenManager = tokenManager;
        }

        public IGhiseuRepository Ghisee => _ghiseuRepository;
        public IBonRepository Bonuri => _bonRepository;
        public IUserRepository Users => _userRepository;
        public ITokenManager TokenManager => _tokenManager;
    }
}
