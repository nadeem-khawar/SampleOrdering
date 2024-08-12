using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using SampleOrdering.Shared.Hosting.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
namespace SampleOrdering.Shared.Hosting.Gateways
{
    [DependsOn(
        typeof(SharedHostingAspNetCoreModule)
    )]
    public class SharedHostingGatewayModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            context.Services.AddHttpForwarderWithServiceDiscovery();

            context.Services.AddReverseProxy()
                .LoadFromConfig(configuration.GetSection("ReverseProxy"))
                .AddServiceDiscoveryDestinationResolver();
        }
    }
}
