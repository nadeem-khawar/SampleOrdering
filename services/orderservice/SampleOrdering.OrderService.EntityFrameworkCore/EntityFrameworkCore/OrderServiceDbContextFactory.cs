using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleOrdering.OrderService.Domain;
namespace SampleOrdering.OrderService.EntityFrameworkCore.EntityFrameworkCore
{
    public class OrderServiceDbContextFactory : IDesignTimeDbContextFactory<OrderServiceDbContext>
    {
        public OrderServiceDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<OrderServiceDbContext>()
                .UseNpgsql(
                    configuration.GetConnectionString(OrderServiceDbProperties.ConnectionStringName),
                    b =>
                    {
                        b.MigrationsHistoryTable("__OrderService_Migrations");
                    });

            // https://www.npgsql.org/efcore/release-notes/6.0.html#opting-out-of-the-new-timestamp-mapping-logic
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            return new OrderServiceDbContext(builder.Options);
        }
        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../SampleOrdering.OrderService.HttpApi.Host/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
