using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace SampleOrdering.UserService.HttpApi
{
    public abstract class UserServiceController : AbpControllerBase
    {
        protected UserServiceController() { }
    }
}
