using Microsoft.Extensions.DependencyInjection;
using SampleOrdering.UserService.Application.Contracts;
using SampleOrdering.UserService.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace SampleOrdering.UserService.Application
{
    [DependsOn(
        typeof(UserServiceApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(UserServiceDomainModule),
        typeof(AbpAutoMapperModule)
    )]
    public class UserServiceApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<UserServiceApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<UserServiceApplicationModule>(validate: true);
            });
        }
    }
}
