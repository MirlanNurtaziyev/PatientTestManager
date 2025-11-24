using System.Data;

namespace PatientTestManager.Domain.Interfaces
{
    public interface IReportRepository
    {
        Task<DataTable> GetReportDataAsync(DateTime fromDate, DateTime toDate);
    }
}