using Course_mvc_iTi.Migrations;
using Course_mvc_iTi.Models;
using Course_mvc_iTi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Course_mvc_iTi.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> appUser;
        private readonly SignInManager<ApplicationUser> signIn;
        public AccountController(UserManager<ApplicationUser> appUser, SignInManager<ApplicationUser> signIn)
        {
            this.appUser = appUser;
            this.signIn = signIn;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AccountRegisterViewModel NewAccount)
        {
            if (ModelState.IsValid)
            {
                //mapping From Vm To model 
                ApplicationUser user = new ApplicationUser();
                user.Email = NewAccount.Email;
                user.Address = NewAccount.Address;
                user.PasswordHash = NewAccount.Password;
                user.UserName = NewAccount.Name;

                IdentityResult result = await appUser.CreateAsync(user, user.PasswordHash);
                if (result.Succeeded)
                {
                    // Create Cookie

                    await signIn.SignInAsync(user, false);
                    await appUser.AddToRoleAsync(user, "Student");
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("Name", item.Description);

                    }
                }
            }
            return View(NewAccount);

        }
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AccountLoginViewModel Login)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser LoginUser = await appUser.FindByNameAsync(Login.Name);
                if (LoginUser != null)
                {
                    bool found = await appUser.CheckPasswordAsync(LoginUser, Login.Password);
                    if (found)
                    {
                        await signIn.SignInAsync(LoginUser, Login.RememberMe);
                        return RedirectToAction("Index", "Instructor");
                    }
                }
                ModelState.AddModelError("", "User Name Or password is Wrong ");
            }

            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await signIn.SignOutAsync();//Delete Cookie 
            return RedirectToAction("Register");
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddAdmin()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> AddAdmin(AccountRegisterViewModel Newadmin)
        {
            if (ModelState.IsValid)
            {
                // save db 
                ApplicationUser user = new ApplicationUser();
               user.Email = Newadmin.Email;
                user.Address = Newadmin.Address;
                user.PasswordHash = Newadmin.Password;
                user.UserName = Newadmin.Name;

                IdentityResult result = await appUser.CreateAsync(user,Newadmin.Password);
                if (result.Succeeded)
                {
                    
                    await appUser.AddToRoleAsync(user, "Admin");
                    await signIn.SignInAsync(user, false);
                    return RedirectToAction("Index", "Instructor");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }
            }
            return View(Newadmin);
        }


    }
}
