using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using WebApplicationGIS46.Models;
using WebApplicationGIS46.Repository;
using WebApplicationGIS46.ViewModel;

namespace WebApplicationGIS46.Controllers
{
    public class EmployeeController : Controller
    {
        //ITIContext  context=new ITIContext();
        IEmployeeRepo EmpRepo;
        IDepartmentRepo DeptRepo;
        public EmployeeController(IEmployeeRepo empRepo,IDepartmentRepo deptRepo)//ask constructor =>service Provider
        {
            EmpRepo = empRepo;// new EmployeeRepsitory();
            DeptRepo = deptRepo;//new DepartmentRepository();
        }
        [Authorize]//check cookie identity
        public IActionResult Index()
        {
            return View("Index", EmpRepo.GetAll());
        }
        //Employee/CheckSalary? Salary = 11 &DepartmentId=1
        public IActionResult CheckSalary(int Salary,int DepartmentId)
        {
            if (Salary > 7000)
            {
                return Json(true);
            }
            return Json("Salary Must be More Than 7000");
        }

        #region NEw
        public IActionResult New()
        {
            ViewData["DeptList"] = DeptRepo.GetAll();
            return View("New");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//request.key["_vertoo"]
        public IActionResult SaveNew(Employee empFromRequest)
        {
            //if(empFromRequest.Name != null&& empFromRequest.Salary>7000) {
            if (ModelState.IsValid==true)
            {
                try
                {
                    EmpRepo.Add (empFromRequest);
                    EmpRepo.Save();
                    return RedirectToAction("Index", "Employee");
                }catch(Exception ex)
                {
                    ModelState.AddModelError(key: "anykey", errorMessage: ex.InnerException.Message);
                }
            }
            ViewData["DeptList"] = DeptRepo.GetAll();
            return View("New", empFromRequest);
        }
        #endregion

        #region Edit
        public IActionResult Edit(int id)
        {
            //collect
            //get employee
            Employee empModel = EmpRepo.GetById( id);
            List<Department> departmentList = DeptRepo.GetAll();
            if(empModel == null)
            {
                return NotFound();
            }
            //declare ,map
            EmpWithDeptListViewModel empvm=new()
            {
                Id=empModel.Id,
                EmpName=empModel.Name,
                EmpSalary=empModel.Salary,
                ImageURL=empModel.ImageURL,
                DepartmentId=empModel.DepartmentId,
                DepartmentList=departmentList
            };
            //return
            //send vieew
            return View("Edit", empvm);
        }
        //url:/Employee/SaveEdit/1 formdata post { Name=,Salary=,ImageURL=,DepartmentId=} -->
        [HttpPost]
        public IActionResult SaveEdit(EmpWithDeptListViewModel empFromReq)
        {
            if(empFromReq.EmpName != null) {
                //get old refernce fro database (track)
                Employee empFromDB = new();//context.Employees.FirstOrDefault(e=>e.Id==empFromReq.Id);
                //map
                empFromDB.Id = empFromReq.Id;
                empFromDB.Name = empFromReq.EmpName;
                empFromDB.Salary = empFromReq.EmpSalary;
                empFromDB.ImageURL = empFromReq.ImageURL;
                empFromDB.DepartmentId = empFromReq.DepartmentId;
                EmpRepo.Update(empFromDB);
                //save change
                // context.SaveChanges();
                EmpRepo.Save();
                return RedirectToAction(actionName: "Index",controllerName:"Employee");
            }
            List<Department> departmentList = DeptRepo.GetAll();
            empFromReq.DepartmentList=departmentList;//refill non coming property

            return View("Edit", empFromReq);//{name=,empsa=200,deplartment=6}
        }
        #endregion

        #region DEtails
        public IActionResult Details(int id,string name)
        {
            string msg = "hello";
            List<string> DeptList=DeptRepo.GetAll().Select(d=>d.Name).ToList();
            int temp = 10;
            //Fill Write
            ViewData["MSG"] = msg;
            ViewData["Temp"] = temp;
            ViewData["DeptList"] = DeptList;
            ViewBag.color = "red";
            ViewData["color123"] = "blue";//color blue or red or exception

            Employee emp= EmpRepo.GetById( id);
            return View("Details",emp);
        }
        public IActionResult DetailsVM(int id)
        {
            //Collect
            string msg = "hello";
            List<string> DeptList = DeptRepo.GetAll().Select(x => x.Name).ToList();
            int temp = 10;

            Employee emp = EmpRepo.GetById( id);
            //DEcalre ViewModel  -mapping
            EmpWithMsgTempDeptListColorViewModel empVM = new () { 
                EmpId=emp.Id,
                EmpName=emp.Name,
                Color="red",
                Temp=temp,
                Msg=msg,    
                Departments=DeptList
            };
            return View("DetailsVM", empVM);//View "DetailsVM" Model =EmpWithMsgTempDeptListColorViewModel
        }
        #endregion
    }
}
