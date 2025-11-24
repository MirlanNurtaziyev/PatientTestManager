using Autofac;
using Microsoft.Extensions.Logging;
using PatientTestManager.Services.Interfaces;
using PatientTestManager.Services.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PatientTestManager.Services
{

    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            builder.RegisterInstance(Log.Logger)
                   .As<Serilog.ILogger>()
                   .SingleInstance();

            builder.RegisterType<ReportService>()
               .As<IReportService>()
               .InstancePerLifetimeScope();
        }
    }
}
