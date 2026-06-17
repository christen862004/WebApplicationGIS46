using Microsoft.AspNetCore.Mvc;

namespace WebApplicationGIS46.Controllers
{
  //  [Route("r1")]
    public class RouteController : Controller
    {
        //default route :/Route/Method1/122?name=ahmed&age=12
        //default route :/Route/Method1?name=ahmed&age=12&id=122
        //r1?name=ahmed&age=12   X
        //r1/12/ahmed
        //r1/22/sara
        //[HttpGet("/gg")]//r1/gg
        [HttpGet("r1/{age:int}/{name?}")]//r1/20/1hmed
        //[Route("r1/{age:int}/{name?}",Name ="rout3")]//the only way to reach to this action  /Route/MEthod1 (not found)
        public IActionResult Method1(int age,string name,int id)
        {
            return Content("Method1");
        }
        //Route/MEthod2
        //r2
        public IActionResult Method2()
        {
            return Content("Method2");
        }
    }
}
