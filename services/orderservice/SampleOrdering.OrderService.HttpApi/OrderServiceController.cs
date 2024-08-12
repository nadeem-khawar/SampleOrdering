using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace SampleOrdering.OrderService.HttpApi
{
    public abstract class OrderServiceController : AbpControllerBase
    {
        protected OrderServiceController() { }
    }
}
