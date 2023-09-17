using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.Filters
{
    public class CustomFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            int i = 10;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            int i = 20;
        }


    }
}
