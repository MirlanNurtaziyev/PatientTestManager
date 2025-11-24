using PatientTestManager.Services.DTO;

namespace PatientTestManager.Services.Interfaces
{
    public interface ITestService
    {
        Task<TestDto?> GetTestByIdAsync(int testId);
        Task<IEnumerable<TestDto>> GetTestsByPatientIdAsync(int patientId);
        Task<IEnumerable<TestDto>> GetAllTestsAsync();
        Task<TestDto> CreateTestAsync(TestDto testDto);
        Task<bool> UpdateTestAsync(TestDto testDto);
        Task<bool> DeleteTestAsync(int testId);
    }
}