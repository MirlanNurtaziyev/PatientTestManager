using PatientTestManager.Domain.Entities;

namespace PatientTestManager.Domain.Interfaces
{
    public interface ITestRepository
    {
        Task<Test?> GetTestByIdAsync(int testId);
        Task<IEnumerable<Test>> GetTestsByPatientIdAsync(int patientId);
        Task<IEnumerable<Test>> GetAllTestsAsync();
        Task<Test> AddTestAsync(Test test);
        Task<bool> EditTestAsync(Test test);
        Task<bool> DeleteTestAsync(int testId);
        Task<int> SaveChangesAsync();
    }
}