using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Entities;

namespace WebApplication1.Models
{
    public class EmployeeAddViewModel
    {
        public EmployeeAddViewModel()
        {
        }

        public Employee Employee { get; set; }
        public List<SelectListItem> Cities { get; internal set; }
    }
}