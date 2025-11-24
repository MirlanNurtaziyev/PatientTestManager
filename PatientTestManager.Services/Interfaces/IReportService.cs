using System.Data;

namespace PatientTestManager.Services.Interfaces
{
    public interface IReportService
    {
        Task<DataTable> GetReportDataAsync(DateTime fromDate, DateTime toDate);
    }
}