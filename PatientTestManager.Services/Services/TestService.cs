using PatientTestManager.Domain.Entities;
using PatientTestManager.Domain.Interfaces;
using PatientTestManager.Services.DTO;
using PatientTestManager.Services.Interfaces;

namespace PatientTestManager.Services.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IPatientRepository _patientRepository;

        public TestService(ITestRepository testRepository, IPatientRepository patientRepository)
        {
            _testRepository = testRepository;
            _patientRepository = patientRepository;
        }

        public async Task<TestDto?> GetTestByIdAsync(int testId)
        {
            var test = await _testRepository.GetTestByIdAsync(testId);
            return test != null ? MapToDto(test) : null;
        }

        public async Task<IEnumerable<TestDto>> GetTestsByPatientIdAsync(int patientId)
        {
            var tests = await _testRepository.GetTestsByPatientIdAsync(patientId);
            return tests.Select(MapToDto).ToList();
        }

        public async Task<IEnumerable<TestDto>> GetAllTestsAsync()
        {
            var tests = await _testRepository.GetAllTestsAsync();
            return tests.Select(MapToDto).ToList();
        }

        public async Task<TestDto> CreateTestAsync(TestDto testDto)
        {
            if (testDto == null)
                throw new ArgumentNullException(nameof(testDto));

            ValidateTestDto(testDto);

            var test = MapToEntity(testDto);
            var createdTest = await _testRepository.AddTestAsync(test);

            return MapToDto(createdTest);
        }

        public async Task<bool> UpdateTestAsync(TestDto testDto)
        {
            if (testDto == null)
                throw new ArgumentNullException(nameof(testDto));

            ValidateTestDto(testDto);

            var test = MapToEntity(testDto);
            return await _testRepository.EditTestAsync(test);
        }

        public async Task<bool> DeleteTestAsync(int testId)
        {
            return await _testRepository.DeleteTestAsync(testId);
        }

        private void ValidateTestDto(TestDto testDto)
        {
            if (testDto.PatientId <= 0)
                throw new ArgumentException("Valid patient ID is required.", nameof(testDto.PatientId));

            if (string.IsNullOrWhiteSpace(testDto.TestName))
                throw new ArgumentException("Test name is required.", nameof(testDto.TestName));

            if (testDto.TestDate == default)
                throw new ArgumentException("Test date is required.", nameof(testDto.TestDate));

            if (testDto.Result < 0)
                throw new ArgumentException("Test result cannot be negative.", nameof(testDto.Result));
        }

        private TestDto MapToDto(Test test)
        {
            return new TestDto
            {
                Id = test.Id,
                PatientId = test.PatientId,
                TestName = test.TestName,
                TestDate = test.TestDate,
                Result = test.Result,
                IsWithinThreshold = test.IsWithinThreshold,
                Patient = test.Patient != null ? MapPatientToDto(test.Patient) : null
            };
        }

        private PatientDto MapPatientToDto(Patient patient)
        {
            return new PatientDto
            {
                Id = patient.Id,
                Name = patient.Name,
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender
            };
        }

        private Test MapToEntity(TestDto testDto)
        {
            return new Test
            {
                Id = testDto.Id,
                PatientId = testDto.PatientId,
                TestName = testDto.TestName,
                TestDate = testDto.TestDate,
                Result = testDto.Result,
                IsWithinThreshold = testDto.IsWithinThreshold
            };
        }
    }
}