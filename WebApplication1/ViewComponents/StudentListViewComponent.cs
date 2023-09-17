using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.ViewComponents
{
    public class StudentListViewComponent : ViewComponent
    {
        public List<Student> students = new List<Student>(){
                new Student() { StudentId = 1, StudentClass = "12/B", StudentName = "YahyaTezcan" },
                new Student() { StudentId = 2, StudentClass = "2/B", StudentName = "ZeynepTezcan" },
                new Student() { StudentId = 6, StudentClass = "1/B", StudentName = "Tezcan" }
            };
        public ViewViewComponentResult Invoke(string? filter)
        {
            filter = HttpContext.Request.Query["filter"];//linkten sorgu için ?filter=a
            if (!String.IsNullOrEmpty(filter))
            {
                return View(new StudentListViewModel
                {
                    Students = students.Where(x => x.StudentName.ToLower().Contains(filter.ToLower())).ToList(),
                });
            }
            return View(new StudentListViewModel
            {
                Students = students.ToList(),
            });
        }
    }
}
