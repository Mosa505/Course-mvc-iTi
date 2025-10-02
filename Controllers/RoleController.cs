using Course_mvc_iTi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Course_mvc_iTi.Controllers
{
    [Authorize(Roles = "Admin,HR")] // Cookie Found or not 
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        [HttpGet]
        [AllowAnonymous] // Remove Authorize Her Any one Can Make Access 
        public IActionResult NewRole()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewRole(RolesViewModel role)
        {
            if (ModelState.IsValid)
            {
                //Save Db 
                IdentityRole roleModel = new IdentityRole();
                roleModel.Name = role.RoleName;

                IdentityResult result = await roleManager.CreateAsync(roleModel);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index" , "Home");
                }
                else
                {
                    foreach(var Item in result.Errors)
                    ModelState.AddModelError("", Item.Description);
                }

            }

            return View(role);

        }
    }
}
