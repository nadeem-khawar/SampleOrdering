using SampleOrdering.UserService.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace SampleOrdering.UserService.Domain
{
    [DependsOn(
    typeof(UserServiceDomainSharedModule),
    typeof(AbpDddDomainModule)
    )]
    public class UserServiceDomainModule:AbpModule
    {
    }
}
