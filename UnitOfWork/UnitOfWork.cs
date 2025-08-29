using ServiciiPubliceBackend.Repositories;

namespace ServiciiPubliceBackend.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IGhiseuRepository _ghiseuRepository;
        private readonly IBonRepository _bonRepository;

        public UnitOfWork(IGhiseuRepository ghiseuRepository, IBonRepository bonRepository)
        {
            _ghiseuRepository = ghiseuRepository;
            _bonRepository = bonRepository;
        }

        public IGhiseuRepository Ghisee => _ghiseuRepository;
        public IBonRepository Bonuri => _bonRepository;
    }
}
