using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationGIS46.Models
{
    public class Employee
    {
        public int Id { get; set; }
        //[Required]
        [Unique]
        [StringLength(50,MinimumLength =2,ErrorMessage ="NAme must be between 2 char to 50 char")]
        //[MinLength(2)]
        //[MaxLength(50)]
        public string Name { get; set; }
        [RegularExpression(@"\w+\.(jpg|png)",ErrorMessage ="Image must be jpg or png ex:asd.png")]//sdksahjk232.jpg |fsdf.png
        public string? ImageURL { get; set; }
        //[Range(7000,50000)]
        //[Required]
        //[MoreThan(6000,ErrorMessage ="Salary must be more 6000")]
        [Remote("CheckSalary","Employee",AdditionalFields = "DepartmentId")]//get "/Employee/CheckSalary?Salary=11"
        public int Salary { get; set; }
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        
        public Department? Department { get; set; }
    }
}
