using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;

namespace SampleOrdering.UserService.Domain.Shared
{
    [DependsOn(
        typeof(AbpValidationModule)
        )]
    public class UserServiceDomainSharedModule: AbpModule
    {
    }
}
