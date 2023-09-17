using WebApplication1.Entities;

namespace WebApplication1.Models
{
    public class EmployeeListViewModel
    {
        public EmployeeListViewModel()
        {
        }

        public List<Employee> Employees { get; set; }
        public List<string> Cities { get; set; }
    }
}