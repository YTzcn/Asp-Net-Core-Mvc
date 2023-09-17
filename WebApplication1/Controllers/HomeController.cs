using System.Diagnostics;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NuGet.Packaging;
using WebApplication1.Entities;
using WebApplication1.Filters;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
        [HandleException(ViewName = "DevideByZeroException", ExceptionType = typeof(DivideByZeroException))]
        public ViewResult Index2()
        {
            throw new DivideByZeroException();
        }
        public ViewResult Index3()
        {
            List<Employee> employees = new List<Employee>() {
                new Employee() { Id = 0 , CityId=2,Name="Ahmet",SurName="Topal" },
                new Employee() { Id = 1 , CityId=2,Name="Yahya",SurName="Tezcan" },
                new Employee() { Id = 2 , CityId=2,Name="Mustafa",SurName="Tezcan" }
                };
            List<string> cities = new List<string>() { "İstanbul", "Ankara", "İzmir" };
            var employeeListViewModel = new EmployeeListViewModel()
            {
                Employees = employees,
                Cities = cities
            };
            return View(employeeListViewModel);
        }
        public StatusCodeResult Index4()
        {
            return StatusCode(200);
            //return Ok();
            //return NotFound()
        }
        public IActionResult Index5()
        {
            return BadRequest();
        }
        public RedirectResult Index6()
        {
            return Redirect("Index3");
        }
        public IActionResult Index7()
        {
            return RedirectToAction("Index4");
        }
        public IActionResult Index8()
        {
            return RedirectToRoute("default");
        }
        public JsonResult Index9()
        {
            List<Employee> employees = new List<Employee>() {
                new Employee() { Id = 0 , CityId=2,Name="Ahmet",SurName="Topal" },
                new Employee() { Id = 1 , CityId=2,Name="Yahya",SurName="Tezcan" },
                new Employee() { Id = 2 , CityId=2,Name="Mustafa",SurName="Tezcan" }
                };

            return Json(employees);
        }
        public ActionResult RazorDemo()
        {
            List<Employee> employees = new List<Employee>() {
                new Employee() { Id = 0 , CityId=2,Name="Ahmet",SurName="Topal" },
                new Employee() { Id = 1 , CityId=2,Name="Yahya",SurName="Tezcan" },
                new Employee() { Id = 2 , CityId=2,Name="Mustafa",SurName="Tezcan" }
                };
            List<string> cities = new List<string>() { "İstanbul", "Ankara", "İzmir" };
            var employeeListViewModel = new EmployeeListViewModel()
            {
                Employees = employees,
                Cities = cities
            };
            return View(employeeListViewModel);
        }
        public JsonResult Index10(string key)//https://localhost:7018/Home/Index10?key=y
        {
            List<Employee> employees = new List<Employee>() {
                new Employee() { Id = 0 , CityId=2,Name="Ahmet",SurName="Topal" },
                new Employee() { Id = 1 , CityId=2,Name="Yahya",SurName="Tezcan" },
                new Employee() { Id = 2 , CityId=2,Name="Mustafa",SurName="Tezcan" }
                };
            var result = employees;
            if (!String.IsNullOrEmpty(key))
            {
                result = employees.Where(x => x.Name.ToLower().Contains(key)).ToList();
            }

            return Json(result);
        }
        public string RouteData(int Id)
        {
            return Id.ToString();
        }

    }
}