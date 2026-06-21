using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplicationGIS46.Models;
using WebApplicationGIS46.ViewModel;

namespace WebApplicationGIS46.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel userFromRequest)
        {
            if (ModelState.IsValid)
            {
                //mapping vm =>applicationuser
                ApplicationUser appUser = new ApplicationUser()
                {
                    UserName = userFromRequest.UserName,
                    PasswordHash = userFromRequest.Password,
                    Address = userFromRequest.Address,
                };
                //save db
                IdentityResult result=await  userManager.CreateAsync(appUser,userFromRequest.Password);
                if (result.Succeeded)
                {
                    //assign user to role admin
                    await userManager.AddToRoleAsync(appUser, "Admin");
                    //creat cookie
                    //create cookie (id,username,email? ,roler?)
                    await signInManager.SignInAsync(appUser, false);//id,name,role,email?
                    return RedirectToAction("Index", "employee");
                }
                //send error to view
                foreach (var errorItem in result.Errors)
                {
                    ModelState.AddModelError("", errorItem.Description);
                }
            }
            return View("Register",userFromRequest);
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel userFromRequest)
        {
            if (ModelState.IsValid)
            {
                //check 
                ApplicationUser appUser=await userManager.FindByNameAsync(userFromRequest.UserName);
                if (appUser != null)
                {
                    bool found=await userManager.CheckPasswordAsync(appUser, userFromRequest.Password);
                    if(found)
                    {
                        List<Claim> extraClaim = new List<Claim>();
                        extraClaim.Add(new Claim("Address", appUser.Address));
                        //cookie
                        await signInManager.SignInWithClaimsAsync(appUser, userFromRequest.RememberMe, extraClaim);
                        //await signInManager.SignInAsync(appUser, userFromRequest.RememberMe);//id , username,role? ,email? +extra claim
                        return RedirectToAction("Index", "Employee");
                    }

                }
                ModelState.AddModelError("", "Invalid Account");
            }
            return View("Login", userFromRequest);
        }
        #endregion

        #region Logout
        public async Task< IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();//remove cookie
            return RedirectToAction("Login", "Account");
        }
        #endregion
    }
}
