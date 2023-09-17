using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.ExtensionMethods;

namespace WebApplication1.Controllers
{
    public class SessionDemoController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public SessionDemoController(IHttpContextAccessor httpContext)
        {
            _contextAccessor = httpContext;
        }
        public string Index()
        {
            _contextAccessor.HttpContext.Session.SetInt32("Age", 18);
            _contextAccessor.HttpContext.Session.SetString("Name", "Yahya");
            _contextAccessor.HttpContext.Session.SetObject("Student",new Student() { StudentClass = "1sd", StudentId = 1, StudentName = "dflsjh" });
            return "SESSİON OK";
        }
        public string GetSessions()
        {
            return String.Format("Hello {0},you are {1}   {2}  ", _contextAccessor.HttpContext.Session.GetString("Name"), _contextAccessor.HttpContext.Session.GetInt32("Age")+ _contextAccessor.HttpContext.Session.GetObject<Student>("Student").StudentName);

        }
    }
}
