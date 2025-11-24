using System.Data;
using Microsoft.Data.SqlClient;
using PatientTestManager.Data.Interfaces;
using PatientTestManager.Domain.Interfaces;

namespace PatientTestManager.Data.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly IConnectionStringProvider _connectionStringProvider;

        public ReportRepository(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        public async Task<DataTable> GetReportDataAsync(DateTime fromDate, DateTime toDate)
        {
            if (fromDate > toDate)
                throw new ArgumentException("FromDate cannot be greater than ToDate.");

            try
            {
                var connectionString = _connectionStringProvider.GetConnectionString();

                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("dbo.GenerateReport", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@FromDate", fromDate);
                        command.Parameters.AddWithValue("@ToDate", toDate);

                        var dataTable = new DataTable();
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }

                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error calling stored procedure: {ex.Message}", ex);
            }
        }
    }
}