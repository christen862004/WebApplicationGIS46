using Microsoft.AspNetCore.Mvc;
using WebApplicationGIS46.Models;
using WebApplicationGIS46.Repository;

namespace WebApplicationGIS46.Controllers
{
    public class DepartmentController : Controller
    {
        // ITIContext context = new ITIContext();
        IDepartmentRepo DEptRepo;
        public DepartmentController(IDepartmentRepo deptRepo)//ask about depency DIP +IOC +DI
        {
            DEptRepo = deptRepo;// new DepartmentRepository();
        }
        public IActionResult Index()
        {
            List<Department> deptList= DEptRepo.GetAll();
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
                DEptRepo.Add(deptFromReq);
                DEptRepo.Save();
                return RedirectToAction(actionName:"Index",controllerName:"Department") ;
            }
            return View(viewName:"New",model:deptFromReq);//new ,model =>departmentr
        }
        #endregion
    }
}
