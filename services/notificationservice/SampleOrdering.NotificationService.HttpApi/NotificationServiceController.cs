using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace SampleOrdering.NotificationService.HttpApi
{
    public abstract class NotificationServiceController : AbpControllerBase
    {
        protected NotificationServiceController() { }
    }
}
