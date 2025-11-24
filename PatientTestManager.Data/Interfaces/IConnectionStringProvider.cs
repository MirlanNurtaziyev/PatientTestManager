namespace PatientTestManager.Data.Interfaces
{
    public interface IConnectionStringProvider
    {
        string GetConnectionString(string name = "DefaultConnection");
    }
}