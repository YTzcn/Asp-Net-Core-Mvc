using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WebApplication1.Entities;

namespace WebApplication1.TagHelpers
{
    [HtmlTargetElement("employee-list")]
    public class EmployeeListTagHelper : TagHelper
    {
        public List<Employee> _employees;
        public EmployeeListTagHelper()
        {
            _employees = new List<Employee>()
            {
                new Employee{ Id = 0, CityId = 2, Name = "Ahmet", SurName = "Topal" },
                new Employee{ Id = 1, CityId = 2, Name = "Yahya", SurName = "Tezcan" },
                new Employee{ Id = 2, CityId = 2, Name = "Mustafa", SurName = "Tezcan" }
            };
        }

        private const string ListCountAttributeName = "count";
        [HtmlAttributeName(ListCountAttributeName)]
        public int ListCount { get; set; }
        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            var query = _employees.Take(ListCount);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var employee in query)
            {
                stringBuilder.AppendFormat("<h2><a href='Employee/Detail/{0}'>{1}</a></h2>", employee.Id, employee.Name);
            }
            output.Content.SetHtmlContent(stringBuilder.ToString());
            base.Process(context, output);
        }
    }
}
