using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Customer
{
    public class IndexModel : PageModel
    {
        public int MyInt = 0;
        public void OnGet()
        {
            Random random = new Random();   
            MyInt = random.Next();
        }
    }
}
