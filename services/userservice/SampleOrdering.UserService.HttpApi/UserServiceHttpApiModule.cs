using Microsoft.Extensions.DependencyInjection;
using SampleOrdering.UserService.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace SampleOrdering.UserService.HttpApi
{
    [DependsOn(
        typeof(UserServiceApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class UserServiceHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(UserServiceHttpApiModule).Assembly);
            });
        }
    }
}
