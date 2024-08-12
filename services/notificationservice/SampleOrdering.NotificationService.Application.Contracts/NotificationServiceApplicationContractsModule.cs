using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application;
using Volo.Abp.Modularity;
using SampleOrdering.NotificationService.Domain.Shared;
namespace SampleOrdering.NotificationService.Application.Contracts
{
    [DependsOn(
    typeof(NotificationServiceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule)
    )]
    public class NotificationServiceApplicationContractsModule:AbpModule
    {
    }
}
