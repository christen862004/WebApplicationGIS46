using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplicationGIS46.ViewModel;

namespace WebApplicationGIS46.Controllers
{
    [Authorize(Roles = "Admin")]//check cookie & claim roles =Admin
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        [HttpGet]//link
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]//submit
        [Authorize]
        public async Task<IActionResult> Create(RoleViewModel roleFromReq)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole()
                {
                    Name = roleFromReq.RoleName
                };
                //create db using 
                IdentityResult result= await roleManager.CreateAsync(role);
                if(result.Succeeded){
                    return RedirectToAction("Index", "department");
                }
                foreach (var errotItem in result.Errors)
                {
                    ModelState.AddModelError("", errotItem.Description);
                }
            }
            return View("Create",roleFromReq);
        }
    }
}
