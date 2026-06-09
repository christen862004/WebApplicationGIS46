using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using WebApplicationGIS46.Models;
using WebApplicationGIS46.ViewModel;

namespace WebApplicationGIS46.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext  context=new ITIContext();
        public IActionResult Index()
        {
            return View("Index", context.Employees.ToList());
        }

        #region Edit
        public IActionResult Edit(int id)
        {
            //collect
            //get employee
            Employee empModel = context.Employees.FirstOrDefault(e => e.Id == id);
            List<Department> departmentList = context.Departments.ToList();
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
                Employee empFromDB= context.Employees.FirstOrDefault(e=>e.Id==empFromReq.Id);
                //map
                empFromDB.Name = empFromReq.EmpName;
                empFromDB.Salary = empFromReq.EmpSalary;
                empFromDB.ImageURL = empFromReq.ImageURL;
                empFromDB.DepartmentId = empFromReq.DepartmentId;
                //save change
                context.SaveChanges();
                return RedirectToAction(actionName: "Index",controllerName:"Employee");
            }
            List<Department> departmentList = context.Departments.ToList();
            empFromReq.DepartmentList=departmentList;//refill non coming property

            return View("Edit", empFromReq);//{name=,empsa=200,deplartment=6}
        }
        #endregion

        #region DEtails
        public IActionResult Details(int id)
        {
            string msg = "hello";
            List<string> DeptList=context.Departments.Select(x => x.Name).ToList();
            int temp = 10;
            //Fill Write
            ViewData["MSG"] = msg;
            ViewData["Temp"] = temp;
            ViewData["DeptList"] = DeptList;
            ViewBag.color = "red";
            ViewData["color123"] = "blue";//color blue or red or exception

            Employee emp= context.Employees.FirstOrDefault(e => e.Id == id);
            return View("Details",emp);
        }
        public IActionResult DetailsVM(int id)
        {
            //Collect
            string msg = "hello";
            List<string> DeptList = context.Departments.Select(x => x.Name).ToList();
            int temp = 10;

            Employee emp = context.Employees.FirstOrDefault(e => e.Id == id);
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
