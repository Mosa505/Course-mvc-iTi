using AspNetCoreGeneratedDocument;
using Course_mvc_iTi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Course_mvc_iTi.Controllers
{
    public class CourseController : Controller
    {

        public CourseDbContext context = new CourseDbContext();
        public IActionResult Index()
        {
            return View(context.courses.ToList());
        }
        public IActionResult Edit(int id)
        {
            Course course = context.courses.FirstOrDefault(e => e.Id == id);

            ViewData["ListOfDepartment"] = context.departments.ToList();


            return View(course);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEdit(int id, Course course)
        {
            Course oldEdit = context.courses.FirstOrDefault(c => c.Id == id);
            if (course.Name != null)
            {

                if (oldEdit != null)
                {
                    oldEdit.Name = course.Name;
                    oldEdit.Degree = course.Degree;
                    oldEdit.MinDegree = course.MinDegree;
                    oldEdit.Dept_Id = course.Dept_Id;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            ViewData["ListOfDepartment"] = context.departments.ToList();
            return View("Edit", course);

        }
        public ActionResult AddCourse()
        {
            ViewData["ListOfDepartment"] = context.departments.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveNew(Course course)
        {
            if (course != null)
            {
                context.courses.Add(course);
                context.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewData["ListOfDepartment"] = context.departments.ToList();
            return View("Edit", course);



        }
        public ActionResult Delete(int id)
        {
            Course course = context.courses.FirstOrDefault(c => c.Id == id);
            if (course != null)
            {
                context.courses.Remove(course);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index", course);

        }

        public IActionResult MinDegree(int MinDegree, int Degree)
        {

            if (MinDegree < Degree)
            {
                return Json(true);
            }
            return Json(false);

        }

    }
}
