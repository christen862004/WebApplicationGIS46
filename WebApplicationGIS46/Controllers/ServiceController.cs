using Microsoft.AspNetCore.Mvc;
using WebApplicationGIS46.Repository;

namespace WebApplicationGIS46.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IService service;

        public ServiceController(IService service)//inject
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            ViewBag.ID = service.ID;//display view
            return View("Index");
        }
    }
}
