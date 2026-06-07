using Microsoft.AspNetCore.Mvc;
using WebApplicationGIS46.Models;

namespace WebApplicationGIS46.Controllers
{
    public class StudentController : Controller
    {
        StudentBL studentBL=new StudentBL();
        //Student/all
        public IActionResult All()
        {
            List<Student> students = studentBL.GetAll();//model
            //return View("ShowAll");//view  ==>Views/Student/Showall.cshtml   model =null
            return View("ShowAll",students);//view  ==>Views/Student/Showall.cshtml   model with type List<student>
        }
    }
}
