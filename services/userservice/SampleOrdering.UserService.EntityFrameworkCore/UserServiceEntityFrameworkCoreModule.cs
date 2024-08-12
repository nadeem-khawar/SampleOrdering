using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.Modularity;
using SampleOrdering.UserService.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using SampleOrdering.UserService.EntityFrameworkCore.EntityFrameworkCore;
namespace SampleOrdering.UserService.EntityFrameworkCore
{
    [DependsOn(
    typeof(UserServiceDomainModule),
    typeof(AbpEntityFrameworkCorePostgreSqlModule)
)]
    public class UserServiceEntityFrameworkCoreModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<UserServiceDbContext>(options =>
            {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
                options.AddDefaultRepositories();
            });

            // https://www.npgsql.org/efcore/release-notes/6.0.html#opting-out-of-the-new-timestamp-mapping-logic
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            Configure<AbpDbContextOptions>(options =>
            {
                /* The main point to change your DBMS.
                 * See also OrderingServiceMigrationsDbContextFactory for EF Core tooling. */
                options.UseNpgsql(b =>
                {
                    b.MigrationsHistoryTable("__UserService_Migrations");
                });
            });
        }
    }
}
