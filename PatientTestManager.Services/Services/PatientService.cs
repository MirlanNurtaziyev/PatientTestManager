using PatientTestManager.Domain.Entities;
using PatientTestManager.Domain.Interfaces;
using PatientTestManager.Services.DTO;
using PatientTestManager.Services.Interfaces;

namespace PatientTestManager.Services.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<PatientDto?> GetPatientByIdAsync(int patientId)
        {
            var patient = await _patientRepository.GetPatientByIdAsync(patientId);
            return patient != null ? MapToDto(patient) : null;
        }

        public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync()
        {
            var patients = await _patientRepository.GetAllPatientsAsync();
            return patients.Select(MapToDto).ToList();
        }

        public async Task<PatientDto> CreatePatientAsync(PatientDto patientDto)
        {
            if (patientDto == null)
                throw new ArgumentNullException(nameof(patientDto));

            ValidatePatientDto(patientDto);

            var patient = MapToEntity(patientDto);
            var createdPatient = await _patientRepository.AddPatientAsync(patient);

            return MapToDto(createdPatient);
        }

        public async Task<bool> UpdatePatientAsync(PatientDto patientDto)
        {
            if (patientDto == null)
                throw new ArgumentNullException(nameof(patientDto));

            ValidatePatientDto(patientDto);

            var patient = MapToEntity(patientDto);
            return await _patientRepository.EditPatientAsync(patient);
        }

        public async Task<bool> DeletePatientAsync(int patientId)
        {
            return await _patientRepository.DeletePatientAsync(patientId);
        }

        private void ValidatePatientDto(PatientDto patientDto)
        {
            if (string.IsNullOrWhiteSpace(patientDto.Name))
                throw new ArgumentException("Patient name is required.", nameof(patientDto.Name));

            if (patientDto.DateOfBirth == default)
                throw new ArgumentException("Patient date of birth is required.", nameof(patientDto.DateOfBirth));

            if (string.IsNullOrWhiteSpace(patientDto.Gender))
                throw new ArgumentException("Patient gender is required.", nameof(patientDto.Gender));
        }

        private PatientDto MapToDto(Patient patient)
        {
            return new PatientDto
            {
                Id = patient.Id,
                Name = patient.Name,
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender,
                Tests = patient.Tests.Select(MapTestToDto).ToList()
            };
        }

        private TestDto MapTestToDto(Test test)
        {
            return new TestDto
            {
                Id = test.Id,
                PatientId = test.PatientId,
                TestName = test.TestName,
                TestDate = test.TestDate,
                Result = test.Result,
                IsWithinThreshold = test.IsWithinThreshold
            };
        }

        private Patient MapToEntity(PatientDto patientDto)
        {
            return new Patient
            {
                Id = patientDto.Id,
                Name = patientDto.Name,
                DateOfBirth = patientDto.DateOfBirth,
                Gender = patientDto.Gender
            };
        }
    }
}