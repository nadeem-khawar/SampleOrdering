using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SampleOrdering.UserService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleOrdering.UserService.EntityFrameworkCore.EntityFrameworkCore
{
    //This class is needed for EF Core console commands
    public class UserServiceDbContextFactory : IDesignTimeDbContextFactory<UserServiceDbContext>
    {
        public UserServiceDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<UserServiceDbContext>()
                .UseNpgsql(
                    configuration.GetConnectionString(UserServiceDbProperties.ConnectionStringName),
                    b =>
                    {
                        b.MigrationsHistoryTable("__UserService_Migrations");
                    });

            // https://www.npgsql.org/efcore/release-notes/6.0.html#opting-out-of-the-new-timestamp-mapping-logic
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            return new UserServiceDbContext(builder.Options);
        }
        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../SampleOrdering.UserService.HttpApi.Host/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
