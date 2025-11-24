using PatientTestManager.Data.Context;
using PatientTestManager.Data.Interfaces;

namespace PatientTestManager.Data.Factories
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly IConnectionStringProvider _connectionStringProvider;

        public DbContextFactory(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        public AppDbContext CreateDbContext()
        {
            return new AppDbContext(_connectionStringProvider.GetConnectionString());
        }
    }
}