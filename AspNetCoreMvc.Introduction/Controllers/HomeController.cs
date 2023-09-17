using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc.Introduction.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
