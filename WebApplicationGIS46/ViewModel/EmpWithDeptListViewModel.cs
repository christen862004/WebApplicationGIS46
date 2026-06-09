using System.ComponentModel.DataAnnotations.Schema;
using WebApplicationGIS46.Models;

namespace WebApplicationGIS46.ViewModel
{
    public class EmpWithDeptListViewModel
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string? ImageURL { get; set; }
        public int EmpSalary { get; set; }
        public int DepartmentId { get; set; }
        public List<Department> DepartmentList { get; set; }
    }
}
