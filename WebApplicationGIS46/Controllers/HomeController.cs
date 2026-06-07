using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationGIS46.Models;

namespace WebApplicationGIS46.Controllers
{
    /*
        1) class sufix (end with ) Controller
        2) class inherit from Controller
     */
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        /*
         * action can resturn  sharethe same parent Actionresult ==>IActionresul
         * 1) content()    ==>ContentResult  
         * 2) View()       ==>ViewResult
         * 3) Json()       ==>JsonResult
         * 4) NotFound()   ==>NotFoundResult
         * 5) Unauthorize()==>UnauthorizeReuslt
         * .....
         */

        //Home/showmsg  ==>Endpoint
        public ContentResult showmsg()
        {
            //logic
            //decalre object
            ContentResult result = new ContentResult();
            //fill
            result.Content = "Hello World";
            //return 
            return result;
        }
        //Home/ShowView
        public ViewResult ShowView()
        {
            //logic
            return View("View1");
        }

        //home/showMix?no=12&name=ahmed&id=99   [Querystring]
        //home/showMix?no=13&name=ali&id=99
        //home/showMix/99?no=13&name=ali   (route values befor ? conller=home ,action=showmix ,id=99)
        public IActionResult ShowMix(int no,string name,int id)
        {
            if(no == 13)
            {
                //logic
                return View("View1");
            }
            else
            {

                return NotFound();
                //NotFoundResult  result = new NotFoundResult();
                //return result;
            }
        }



        //public ViewResult View(string viewname)
        //{
        //    //decalre
        //    ViewResult result = new ViewResult();
        //    //fill
        //    result.ViewName =viewname;
        //    //resturn
        //    return result;
        //}

        /*
         * Method call action
         * 1) method must be public 
         * 2) method cant be static
         * 3) Method cant be overload (only in one case)
         */
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
