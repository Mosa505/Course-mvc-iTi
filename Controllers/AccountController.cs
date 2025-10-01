using Course_mvc_iTi.Migrations;
using Course_mvc_iTi.Models;
using Course_mvc_iTi.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Logout()
        {
            await signIn.SignOutAsync();//Delete Cookie 
            return RedirectToAction("Index", "Home");
        }
    }
}
