using Autofac;
using ConsoleApp.Interfaces;
using ConsoleApp.Interfaces.AnimalInterfaces;
using ConsoleApp.Interfaces.CustomerInterfaces;
using ConsoleApp.Interfaces.DatabaseInterfaces;
using ConsoleApp.Interfaces.MenuInterfaces;
using ConsoleApp.Models;
using ConsoleApp.Models.AnimalModels;
using ConsoleApp.Models.CustomerModels;
using ConsoleApp.Models.DatabaseModels;
using ConsoleApp.Models.MenuModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class AFConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            // Register Main Application
            builder.RegisterType<Application>().As<IApplication>();

            // Setup Mockup Database
            builder.RegisterType<DbManager>().As<IDbManager>().SingleInstance();

            // Register one by one
            builder.RegisterType<DataIO>().As<IDataIO>();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(n =>
                n.Namespace.Contains("Menu") ||
                n.Namespace.Contains("Customer") ||
                n.Namespace.Contains("Animal") ||
                n.Namespace.Contains("Service")
                )
                .As(n => n.GetInterfaces()
                .FirstOrDefault(x => x.Name == "I" + n.Name))
                .AsImplementedInterfaces();

            // Register Delegate Factories
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(n =>
                n.Namespace.Contains("Menu") ||
                n.Namespace.Contains("Customer") ||
                n.Namespace.Contains("Animal") ||
                n.Namespace.Contains("Service")
                );

            return builder.Build();
        }
    }
}
