using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;

namespace SampleOrdering.Shared.Hosting.AspNetCore
{
    [DependsOn(
        typeof(AbpSwashbuckleModule),
        typeof(AbpAutofacModule),
        typeof(AbpDataModule)
    )]
    public class SharedHostingAspNetCoreModule: AbpModule
    {
    }
}
