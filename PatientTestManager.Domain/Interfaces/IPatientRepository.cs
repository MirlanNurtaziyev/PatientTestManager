using PatientTestManager.Domain.Entities;

namespace PatientTestManager.Domain.Interfaces
{
    
    public interface IPatientRepository
    {
        Task<Patient?> GetPatientByIdAsync(int patientId);
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<Patient> AddPatientAsync(Patient patient);
        Task<bool> EditPatientAsync(Patient patient);
        Task<bool> DeletePatientAsync(int patientId);
        Task<int> SaveChangesAsync();
    }
}