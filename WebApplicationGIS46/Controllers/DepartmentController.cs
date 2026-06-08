using Microsoft.AspNetCore.Mvc;
using WebApplicationGIS46.Models;

namespace WebApplicationGIS46.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext context = new ITIContext();
        public IActionResult Index()
        {
            List<Department> deptList= context.Departments.ToList();
            return View("Index",deptList);
        }
    }
}
