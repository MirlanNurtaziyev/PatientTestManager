using Microsoft.EntityFrameworkCore;
using PatientTestManager.Data.Context;
using PatientTestManager.Data.Factories;
using PatientTestManager.Domain.Entities;
using PatientTestManager.Domain.Interfaces;

namespace PatientTestManager.Data.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly IDbContextFactory _contextFactory;

        public TestRepository(IDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Test?> GetTestByIdAsync(int testId)
        {
            if (testId <= 0)
                return null;

            using var context = _contextFactory.CreateDbContext();
            return await context.Tests
                .Include(t => t.Patient)
                .FirstOrDefaultAsync(t => t.Id == testId);
        }

        public async Task<IEnumerable<Test>> GetTestsByPatientIdAsync(int patientId)
        {
            if (patientId <= 0)
                throw new ArgumentException("Patient ID must be greater than zero.", nameof(patientId));

            using var context = _contextFactory.CreateDbContext();
            var patientExists = await context.Patients.AnyAsync(p => p.Id == patientId);
            if (!patientExists)
                throw new InvalidOperationException($"Patient with ID {patientId} does not exist.");

            return await context.Tests
                .Include(t => t.Patient)
                .Where(t => t.PatientId == patientId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Test>> GetAllTestsAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Tests
                .Include(t => t.Patient)
                .ToListAsync();
        }

        public async Task<Test> AddTestAsync(Test test)
        {
            if (test == null)
                throw new ArgumentNullException(nameof(test));

            using var context = _contextFactory.CreateDbContext();
            var patientExists = await context.Patients.AnyAsync(p => p.Id == test.PatientId);
            if (!patientExists)
                throw new InvalidOperationException($"Patient with ID {test.PatientId} does not exist. Cannot add test without valid patient reference.");

            context.Tests.Add(test);
            await context.SaveChangesAsync();
            return test;
        }

        public async Task<bool> EditTestAsync(Test test)
        {
            if (test == null)
                throw new ArgumentNullException(nameof(test));

            using var context = _contextFactory.CreateDbContext();
            var existingTest = await context.Tests.FindAsync(test.Id);
            if (existingTest == null)
                return false;

            var patientExists = await context.Patients.AnyAsync(p => p.Id == test.PatientId);
            if (!patientExists)
                throw new InvalidOperationException($"Patient with ID {test.PatientId} does not exist. Cannot update test with invalid patient reference.");

            existingTest.PatientId = test.PatientId;
            existingTest.TestName = test.TestName;
            existingTest.TestDate = test.TestDate;
            existingTest.Result = test.Result;
            existingTest.IsWithinThreshold = test.IsWithinThreshold;

            context.Tests.Update(existingTest);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTestAsync(int testId)
        {
            if (testId <= 0)
                return false;

            using var context = _contextFactory.CreateDbContext();
            var test = await context.Tests.FindAsync(testId);
            if (test == null)
                return false;

            context.Tests.Remove(test);
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