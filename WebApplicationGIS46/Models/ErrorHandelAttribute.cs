using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplicationGIS46.Models
{
    public class ErrorHandelAttribute :Attribute,IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ViewResult result=new ViewResult();
            result.ViewName= "Error";
            context.Result = result;
        }
    }
}
