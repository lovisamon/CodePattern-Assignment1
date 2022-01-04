using Autofac;
using ConsoleApp.Interfaces.CustomerInterfaces;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Run Autofac Configure
            var container = AFConfig.Configure();

            // Create an instance of IApplication since we are not using a constructor here
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }
        }
    }
}
