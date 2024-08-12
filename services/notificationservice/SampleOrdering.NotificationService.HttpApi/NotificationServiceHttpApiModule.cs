using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;
using SampleOrdering.NotificationService.Application.Contracts;
namespace SampleOrdering.NotificationService.HttpApi
{
    [DependsOn(
    typeof(NotificationServiceApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
    public class NotificationServiceHttpApiModule:AbpModule
    {
    }
}
