using Microsoft.Extensions.DependencyInjection;
using SampleOrdering.OrderService.Domain;
using SampleOrdering.OrderService.EntityFrameworkCore.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.Modularity;

namespace SampleOrdering.OrderService.EntityFrameworkCore
{
    [DependsOn(
        typeof(OrderServiceDomainModule),
        typeof(AbpEntityFrameworkCorePostgreSqlModule)
    )]
    public class OrderServiceEntityFrameworkCoreModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<OrderServiceDbContext>(options =>
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
                    b.MigrationsHistoryTable("__OrderService_Migrations");
                });
            });
        }
    }
}
