using System.ComponentModel.DataAnnotations;

namespace WebApplicationGIS46.Models
{
    //WEB API ,MVC
    //Server Side Only
    public class UniqueAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string? name = value.ToString();
            Employee? empFromRequest= validationContext.ObjectInstance as Employee;

            ITIContext context = new ITIContext();
            Employee? empFromDB=context.Employees
                .FirstOrDefault(e => e.Name == name && e.DepartmentId == empFromRequest.DepartmentId);//Unique per department
            if(empFromDB == null) {
                //sucess
                return ValidationResult.Success;
            }
            //fail
            return new ValidationResult("Name Already Exist :(");
        }
    }
}
