using Microsoft.EntityFrameworkCore;
using PatientTestManager.Data.Factories;
using PatientTestManager.Domain.Entities;
using PatientTestManager.Domain.Interfaces;

namespace PatientTestManager.Data.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IDbContextFactory _contextFactory;

        public PatientRepository(IDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Patient?> GetPatientByIdAsync(int patientId)
        {
            if (patientId <= 0)
                return null;

            using var context = _contextFactory.CreateDbContext();
            return await context.Patients
                .Include(p => p.Tests)
                .FirstOrDefaultAsync(p => p.Id == patientId);
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Patients
                .Include(p => p.Tests)
                .ToListAsync();
        }

        public async Task<Patient> AddPatientAsync(Patient patient)
        {
            if (patient == null)
                throw new ArgumentNullException(nameof(patient));

            using var context = _contextFactory.CreateDbContext();
            context.Patients.Add(patient);
            await context.SaveChangesAsync();
            return patient;
        }

        public async Task<bool> EditPatientAsync(Patient patient)
        {
            if (patient == null)
                throw new ArgumentNullException(nameof(patient));

            using var context = _contextFactory.CreateDbContext();
            var existingPatient = await context.Patients.FindAsync(patient.Id);
            if (existingPatient == null)
                return false;

            existingPatient.Name = patient.Name;
            existingPatient.DateOfBirth = patient.DateOfBirth;
            existingPatient.Gender = patient.Gender;

            context.Patients.Update(existingPatient);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePatientAsync(int patientId)
        {
            if (patientId <= 0)
                return false;

            using var context = _contextFactory.CreateDbContext();
            var patient = await context.Patients.FindAsync(patientId);
            if (patient == null)
                return false;

            context.Patients.Remove(patient);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<int> SaveChangesAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.SaveChangesAsync();
        }
    }
}