using System.Data;
using PatientTestManager.Domain.Interfaces;
using PatientTestManager.Services.Interfaces;

namespace PatientTestManager.Services.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<DataTable> GetReportDataAsync(DateTime fromDate, DateTime toDate)
        {
            if (fromDate > toDate)
                throw new ArgumentException("From date cannot be greater than to date.");

            return await _reportRepository.GetReportDataAsync(fromDate, toDate);
        }
    }
}