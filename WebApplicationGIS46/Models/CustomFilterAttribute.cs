using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplicationGIS46.Models
{
    public class CustomFilterAttribute : Attribute,IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
         //logic
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //loigc
        }
    }
}
