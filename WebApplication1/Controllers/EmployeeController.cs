using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Entities;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
   
        public IActionResult Add()
        {
            var employeeAddViewModel = new EmployeeAddViewModel() 
            {
                Employee = new Employee { },
                Cities = new List<SelectListItem>
                {
                    new SelectListItem{Text ="Ankara",Value="6"},
                    new SelectListItem{Text ="Sivas",Value="58"}
                }
            };
            return View(employeeAddViewModel);
        }
        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            return View();
        }

        
    }
}
