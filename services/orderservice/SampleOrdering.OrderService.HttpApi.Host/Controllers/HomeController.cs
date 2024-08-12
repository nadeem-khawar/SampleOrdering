using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace SampleOrdering.OrderService.HttpApi.Host.Controllers
{
    public class HomeController : AbpController
    {
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}
