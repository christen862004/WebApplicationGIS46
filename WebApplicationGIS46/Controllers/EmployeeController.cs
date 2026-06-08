using Microsoft.AspNetCore.Mvc;
using WebApplicationGIS46.Models;
using WebApplicationGIS46.ViewModel;

namespace WebApplicationGIS46.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext  context=new ITIContext();
        public EmployeeController()
        {
            
        }
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
    }
}
