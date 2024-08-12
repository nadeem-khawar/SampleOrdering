using SampleOrdering.Shared.Hosting.Microservices.DbMigrations.EfCore;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;
using SampleOrdering.UserService.EntityFrameworkCore.EntityFrameworkCore;
namespace SampleOrdering.UserService.HttpApi.Host.DbMigrations
{
    public class UserServiceDatabaseMigrationChecker : PendingEfCoreMigrationsChecker<UserServiceDbContext>
    {
        public UserServiceDatabaseMigrationChecker(IUnitOfWorkManager unitOfWorkManager, IServiceProvider serviceProvider, ICurrentTenant currentTenant, IDistributedEventBus distributedEventBus, IAbpDistributedLock abpDistributedLock, string databaseName) : base(unitOfWorkManager, serviceProvider, currentTenant, distributedEventBus, abpDistributedLock, databaseName)
        {
        }
    }
}
