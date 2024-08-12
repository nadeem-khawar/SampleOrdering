using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace SampleOrdering.UserService.HttpApi.Host.Controllers
{
    public class HomeController : AbpController
    {
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}
