using SampleOrdering.Shared.Hosting.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BackgroundJobs.RabbitMQ;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Modularity;

namespace SampleOrdering.Shared.Hosting.Microservices
{
    [DependsOn(
        typeof(SharedHostingAspNetCoreModule),
        typeof(AbpBackgroundJobsRabbitMqModule),
        typeof(AbpEventBusRabbitMqModule)
    )]
    public class SharedHostingMicroservicesModule:AbpModule
    {
    }
}
