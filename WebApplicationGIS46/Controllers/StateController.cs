using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplicationGIS46.Models;

namespace WebApplicationGIS46.Controllers
{
    //  [ErrorHandel]
    //[Authorize]
    public class StateController : Controller
    {

      //  [Authorize]//cookie
        public IActionResult Welcome()
        {
            if (User.Identity.IsAuthenticated == true)
            {  
                //User.IsInRole("Admin")
                string name = User.Identity.Name;
                Claim IdClaim= User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                Claim AddressClaim = User.Claims.FirstOrDefault(c => c.Type == "Address");
                return Content($"Welcome {name} \t id={IdClaim.Value}\t Address={AddressClaim.Value}");
            }
            //authorize welcome + name
            //gust Welcome gust
            return Content("Welcome Gust");
        }




        //15  14 endpoint [autho]
        public StateController()
        {
            
        }

        #region Filtter
        [ErrorHandel]
       // [AllowAnonymous]//??
        public ActionResult m1() {
            throw new Exception("Some Expection thorw");
        }
       // [ErrorHandel]

        public ActionResult m2()
        {
            throw new Exception("Some Expection thorw");
        }
        #endregion
        #region Session Store
        public IActionResult SetSession(string name,int age)
        {
            //logic db ,service ...
            //state
            HttpContext.Session.SetString("EmpName", name);
            HttpContext.Session.SetInt32("Age", age);
            return Content("Session Store Success");
        }
        public IActionResult Getsession()
        {
            //logic
            string n = HttpContext.Session.GetString("EmpName");
            int? a =  HttpContext.Session.GetInt32("Age");
            return Content($"Name={n}\tAge={a}");
        }
        #endregion

        #region Cookie
        public IActionResult SetCookie(string name,int age) {
            //logic 
            //obj ==>serial tro json =>string (need to search)
            //need write cookie send client (response)
            //session cookie
            HttpContext.Response.Cookies.Append("EmpName", name);//expired when sesssion end
            //Presisiten cookie (cookie with expiration)
            CookieOptions options=new CookieOptions();
            options.Expires = DateTimeOffset.Now.AddDays(1);
           
            HttpContext.Response.Cookies.Append("Age", age.ToString(),options);
            return Content("Cookie Save Success");
        }
        public IActionResult GetCookie()
        {
            string n = HttpContext.Request.Cookies["EmpName"];
            string a = HttpContext.Request.Cookies["Age"];
            return Content($"name={n}\t age={a}");

        }
        #endregion
    }
}
