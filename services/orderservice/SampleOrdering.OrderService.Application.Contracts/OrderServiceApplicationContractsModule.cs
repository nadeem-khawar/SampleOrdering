using SampleOrdering.OrderService.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application;
using Volo.Abp.FluentValidation;
using Volo.Abp.Modularity;

namespace SampleOrdering.OrderService.Application.Contracts
{
    [DependsOn(
    typeof(OrderServiceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpFluentValidationModule)
    )]
    public class OrderServiceApplicationContractsModule : AbpModule
    {
    }
}
