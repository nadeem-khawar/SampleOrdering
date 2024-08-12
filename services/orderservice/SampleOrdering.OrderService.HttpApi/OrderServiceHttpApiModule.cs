using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;
using SampleOrdering.OrderService.Application.Contracts;
using Microsoft.Extensions.DependencyInjection;
namespace SampleOrdering.OrderService.HttpApi
{
    [DependsOn(
        typeof(OrderServiceApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class OrderServiceHttpApiModule:AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(OrderServiceHttpApiModule).Assembly);
            });
        }
    }
}
