using Autofac;
using PatientTestManager.Data;
using PatientTestManager.Data.Interfaces;
using PatientTestManager.Services;
using PatientTestManager.UI;
using PatientTestManager.UI.Infrastructure;
using Serilog;

namespace PatientTestManager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var logPath = Path.Combine(AppContext.BaseDirectory, "logs", "log.txt");
            var logDirectory = Path.GetDirectoryName(logPath);

            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File(logPath, rollingInterval: RollingInterval.Day)
                .CreateLogger();

            try
            {
                var builder = new ContainerBuilder();

                builder.RegisterType<ConnectionStringProvider>()
                       .As<IConnectionStringProvider>()
                       .SingleInstance();

                builder.RegisterModule(new DataModule());
                builder.RegisterModule(new ServiceModule());

                builder.RegisterType<MainForm>().AsSelf();

                var container = builder.Build();

                ApplicationConfiguration.Initialize();

                using (var scope = container.BeginLifetimeScope())
                {
                    var mainForm = scope.Resolve<MainForm>();
                    Application.Run(mainForm);
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}