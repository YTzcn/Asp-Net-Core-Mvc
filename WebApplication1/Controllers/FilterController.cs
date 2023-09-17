using Microsoft.AspNetCore.Mvc;
using WebApplication1.Filters;

namespace WebApplication1.Controllers
{
    public class FilterController : Controller
    {
        [CustomFilter]
        public IActionResult Index()
        {
            return View();
        }
    }
}
