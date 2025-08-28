using ServiciiPubliceBackend.Repositories;

namespace ServiciiPubliceBackend.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GhiseuRepository _ghiseuRepository;
        private readonly BonRepository _bonRepository;

        public UnitOfWork(GhiseuRepository ghiseuRepository, BonRepository bonRepository)
        {
            _ghiseuRepository = ghiseuRepository;
            _bonRepository = bonRepository;
        }

        public GhiseuRepository Ghisee => _ghiseuRepository;
        public BonRepository Bonuri => _bonRepository;
    }
}
