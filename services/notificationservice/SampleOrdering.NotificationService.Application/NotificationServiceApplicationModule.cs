using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application;
using Volo.Abp.Modularity;
using SampleOrdering.NotificationService.Application.Contracts;
using SampleOrdering.NotificationService.Domain;
namespace SampleOrdering.NotificationService.Application
{
    [DependsOn(
    typeof(NotificationServiceApplicationContractsModule),
    typeof(AbpDddApplicationModule),
        typeof(NotificationServiceDomainModule)
)]
    public class NotificationServiceApplicationModule:AbpModule
    {
    }
}
