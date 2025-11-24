using Microsoft.Extensions.Configuration;
using PatientTestManager.Data.Interfaces;

namespace PatientTestManager.UI.Infrastructure
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly IConfiguration _configuration;

        public ConnectionStringProvider()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

            _configuration = builder.Build();
        }

        public string GetConnectionString(string name = "DefaultConnection")
        {
            var connectionString = _configuration.GetConnectionString(name);

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException(
                    $"Connection string '{name}' not found in appsettings.json.");
            }

            return connectionString;
        }
    }
}