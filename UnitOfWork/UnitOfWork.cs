using ServiciiPubliceBackend.Repositories;

namespace ServiciiPubliceBackend.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IGhiseuRepository _ghiseuRepository;
        private readonly IBonRepository _bonRepository;
        private readonly IUserRepository _userRepository;

        public UnitOfWork(IGhiseuRepository ghiseuRepository, IBonRepository bonRepository, IUserRepository userRepository)
        {
            _ghiseuRepository = ghiseuRepository;
            _bonRepository = bonRepository;
            _userRepository = userRepository;
        }

        public IGhiseuRepository Ghisee => _ghiseuRepository;
        public IBonRepository Bonuri => _bonRepository;
        public IUserRepository Users => _userRepository;
    }
}
