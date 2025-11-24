using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using PatientTestManager.Data.Interfaces;
using System.IO;

namespace PatientTestManager.UI.Infrastructure
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly IConfiguration _configuration;

        public ConnectionStringProvider()
        {
            var basePath = AppContext.BaseDirectory;
            var configPath = Path.Combine(basePath, "appsettings.json");

            if (!File.Exists(configPath))
            {
                var projectRoot = Path.Combine(basePath, "..", "..", "..");
                configPath = Path.Combine(projectRoot, "appsettings.json");
            }

            if (!File.Exists(configPath))
            {
                throw new FileNotFoundException(
                    $"Configuration file 'appsettings.json' not found. Searched in: {basePath} and project root.");
            }

            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(configPath)!)
                .AddJsonFile(Path.GetFileName(configPath), optional: false, reloadOnChange: false);

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