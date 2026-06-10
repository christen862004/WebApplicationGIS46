using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationGIS46.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string? ImageURL { get; set; }
        public int Salary { get; set; }
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}
