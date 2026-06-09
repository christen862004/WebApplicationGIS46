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
        #region NEw
        public IActionResult New()
        {
            return View("New");//Model null
        }
        //Department/SaveNew?Name=gg&ManagerName=ahmed
        //Httpost,httpget
        [HttpPost]
        public IActionResult SaveNew(Department deptFromReq)//string Name,string ManagerName)
        {
           // if (Request.Method == "POST"){ }
            if (deptFromReq.Name != null)
            {
                context.Departments.Add(deptFromReq);
                context.SaveChanges();
                return RedirectToAction(actionName:"Index",controllerName:"Department") ;
            }
            return View(viewName:"New",model:deptFromReq);//new ,model =>departmentr
        }
        #endregion
    }
}
