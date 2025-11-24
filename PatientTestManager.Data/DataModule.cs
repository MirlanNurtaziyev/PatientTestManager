using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using PatientTestManager.Data.Factories;
using PatientTestManager.Data.Repositories;
using PatientTestManager.Domain.Interfaces;

namespace PatientTestManager.Data
{
    public class DataModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DbContextFactory>()
                   .As<IDbContextFactory>()
                   .SingleInstance();

            builder.RegisterAssemblyTypes(ThisAssembly)
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            builder.RegisterType<ReportRepository>()
                   .As<IReportRepository>()
                   .InstancePerLifetimeScope();
        }
    }
}
