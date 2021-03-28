using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Shop.Migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = CreateServices();


            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }
        }
        private static IServiceProvider CreateServices()
        {
            return new ServiceCollection()

                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString("Server=.;Database=ShopDB;Trusted_Connection=True;")
                    .ScanIn(typeof(Program).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}
