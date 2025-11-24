using PatientTestManager.Services.DTO;

namespace PatientTestManager.Services.Interfaces
{

    public interface IPatientService
    {
        Task<PatientDto?> GetPatientByIdAsync(int patientId);
        Task<IEnumerable<PatientDto>> GetAllPatientsAsync();
        Task<PatientDto> CreatePatientAsync(PatientDto patientDto);
        Task<bool> UpdatePatientAsync(PatientDto patientDto);
        Task<bool> DeletePatientAsync(int patientId);
    }
}