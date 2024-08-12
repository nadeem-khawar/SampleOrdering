using Microsoft.Extensions.DependencyInjection;
using SampleOrdering.OrderService.Application.Contracts;
using SampleOrdering.OrderService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace SampleOrdering.OrderService.Application
{
    [DependsOn(
        typeof(OrderServiceDomainModule),
        typeof(OrderServiceApplicationContractsModule),
        typeof(AbpDddApplicationModule)
    )]
    public class OrderServiceApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<OrderServiceApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<OrderServiceApplicationModule>(validate: true);
            });
        }
    }
}
