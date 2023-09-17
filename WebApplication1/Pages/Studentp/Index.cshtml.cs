using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Execution;
using WebApplication1.Entities;

namespace WebApplication1.Pages.Studentp
{
    public class IndexModel : PageModel
    {
        public List<Student> students = new List<Student>(){
                new Student() { StudentId = 1, StudentClass = "12/B", StudentName = "YahyaTezcan" },
                new Student() { StudentId = 2, StudentClass = "2/B", StudentName = "ZeynepTezcan" },
                new Student() { StudentId = 6, StudentClass = "1/B", StudentName = "Tezcan" }
            };
        public List<Student> searchedStudents = new List<Student>() { new Student() { StudentId=9, StudentName="Yusuf Tezcan",StudentClass="12/c" } };
        public IndexModel()
        {

        }
        public void OnGet(string key)
        {
            if (!String.IsNullOrEmpty(key))
            {
                searchedStudents.AddRange(students.Where(x => x.StudentName.ToLower().Contains(key)));
            }
            else
            {
                students = students;
            }
        }
        [BindProperty]
        public Student studentt { get; set; }
        public IActionResult OnPost()
        {
            students.Add(studentt);
            return RedirectToPage("/Index");
        }
    }
}
