using Microsoft.AspNetCore.Mvc;

namespace Course_mvc_iTi.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
