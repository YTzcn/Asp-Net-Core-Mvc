using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("admin")]
    public class AdminController : Controller
    {
        [Route("")]
        public string Save()
        {
            return "Saved";
        }
        [Route("update")]
        public string Edit()
        {
            return "Edited";
        }
        [Route("delete/{Id?}")]
        public string Delete(int Id)
        {
            return String.Format("Delete {0}",Id);
        }
    }
}
