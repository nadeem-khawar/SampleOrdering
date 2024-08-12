using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using SampleOrdering.OrderService.Domain.Shared;
namespace SampleOrdering.OrderService.Domain
{
    [DependsOn(
    typeof(AbpDddDomainModule),
            typeof(OrderServiceDomainSharedModule)
)]
    public class OrderServiceDomainModule:AbpModule
    {
    }
}
