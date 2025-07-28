using Course_mvc_iTi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Course_mvc_iTi.Controllers
{
    public class InstructorController : Controller
    {
        public CourseDbContext context = new CourseDbContext();
        public IActionResult Index()
        {
            List<Instructor> ViewAll = context.instructors.ToList();

            return View(ViewAll);
        }

        public IActionResult Detail(int Id)
        {
            var ViewById = context.instructors.Where(E => E.Id == Id).FirstOrDefault();

            return View(ViewById);
        }
    }
}
