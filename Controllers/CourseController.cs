using AspNetCoreGeneratedDocument;
using Course_mvc_iTi.Models;
using Course_mvc_iTi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Course_mvc_iTi.Controllers
{
    public class CourseController : Controller
    {
        ICourseRepository courseRepository;
        public CourseController(ICourseRepository _courseRepository)
        {
            courseRepository = _courseRepository;
        }
        public IActionResult Index()
        {
            return View(courseRepository.GetAll());
        }
        public IActionResult Edit(int id)
        {
            Course course = courseRepository.GetById(id);

            //ViewData["ListOfDepartment"] = context.departments.ToList();


            return View(course);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEdit(int id, Course course)
        {

            if (ModelState.IsValid)
            {
                courseRepository.Update(id, course);
                return RedirectToAction("Index");
            }


            //ViewData["ListOfDepartment"] = context.departments.ToList();
            return View("Edit", course);

        }
        public ActionResult AddCourse()
        {
            //ViewData["ListOfDepartment"] = context.departments.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveNew(Course course)
        {
            if (ModelState.IsValid)
            {
               courseRepository.Insert(course);
                return RedirectToAction("Index");
            }


            //ViewData["ListOfDepartment"] = context.departments.ToList();
            return View("Edit", course);



        }
        public ActionResult Delete(int id)
        {
            
            if (ModelState.IsValid)
            {
                courseRepository.DeleteById(id);
                
                return RedirectToAction("Index");
            }
            return View("Index");

        }

    }
}
