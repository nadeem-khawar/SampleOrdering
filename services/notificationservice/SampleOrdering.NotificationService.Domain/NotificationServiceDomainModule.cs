using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;
using Volo.Abp.Domain;
using SampleOrdering.NotificationService.Domain.Shared;
using SampleOrdering.OrderService.Domain.Shared;
namespace SampleOrdering.NotificationService.Domain
{
    [DependsOn(
        typeof(NotificationServiceDomainSharedModule),
        typeof(OrderServiceDomainSharedModule)
    )]
    public class NotificationServiceDomainModule:AbpModule
    {
    }
}
