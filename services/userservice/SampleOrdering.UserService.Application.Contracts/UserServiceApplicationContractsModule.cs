using SampleOrdering.UserService.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application;
using Volo.Abp.FluentValidation;
using Volo.Abp.Modularity;

namespace SampleOrdering.UserService.Application.Contracts
{
    [DependsOn(
        typeof(UserServiceDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpFluentValidationModule)
        )]
    public class UserServiceApplicationContractsModule : AbpModule
    {
    }
}
