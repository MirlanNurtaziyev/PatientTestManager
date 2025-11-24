using PatientTestManager.Data.Context;

namespace PatientTestManager.Data.Factories
{
    public interface IDbContextFactory
    {
        AppDbContext CreateDbContext();
    }
}