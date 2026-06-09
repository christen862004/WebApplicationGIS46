using Microsoft.AspNetCore.Mvc;
using WebApplicationGIS46.Models;

namespace WebApplicationGIS46.Controllers
{
    public class BindController : Controller
    {
        /*
         1) public
         2) not static
         3) no overload (ony in one case)
         */
        //bind/method1
        [HttpGet]
        public IActionResult method1()
        {
            return Content("M!");
        }
        //[HttpGet]
        //public IActionResult method1(int id)
        //{
        //    return Content("M!");
        //}
        //bind/method1?id=9&name=asdd
        //bind/method1
        [HttpPost]
        public IActionResult method1(int id,string name)
        {
            return Content("M! overload");
        }

        /*
          <form action="http://localhost:20507/bind/test" method="post">
                <input type="text" placeholder="Name" name="UserName">
                <input type="text" placeholder="Name" name="phoneBook[ahmed]">
                <input type="check" placeholder="Name" name="color[1]" value=red>
                <input type="check" placeholder="Name" name="color[0]" value=blue>
                <input type="password" name="PWS">
                <input type="number" name="age">
                <input type="number" name="id">
                <input type="submit" value="Send">
         </form>
         */
        //Test Primitive
        //Bind/test?username=ahmned&age=11&id=1333&color=red&color=blue
        //Bind/test/12121?username=ahmned&age=11&color[1]=red&color[0]=blue
        public IActionResult test(string username,int age,int id,string[] color)
        {
            //return View();
            return Content("test");
        }
        //test collection(list -stack -dictionary)
        //Bind/TestDic?name=christen&phoneBook[hamed]=123&phoneBook[mohamed]=456
        public IActionResult TestDic(string name,Dictionary<string,string> phoneBook) {
            
            return Content("sdfsd");
        }

        //test Custom Class
        //1) create object dept=new()
        //2) search abput public property
        // public IActionResult TestObj(int Id, string Name, string? ManagerName, List<Employee> Employees)
        //bind/testobj?id=12&name=sd&ManagerName=ahmed
        //http://localhost:20507/bind/testobj?id=12&name=sd&ManagerName=ahmed&Employees[0].Name=Hamada
        //http://localhost:20507/bind/testobj/123?name=sd&ManagerName=ahmed&Employees[0].Name=Hamada
        public IActionResult TestObj(Department dept)
        {
            return Content("");
        }
    }
}
