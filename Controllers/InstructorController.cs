using Course_mvc_iTi.Models;
using Course_mvc_iTi.Repository;
using Microsoft.AspNetCore.Mvc;
using NuGet.Frameworks;

namespace Course_mvc_iTi.Controllers
{
    public class InstructorController : Controller
    {
        IInstructorRepository _instructorRepository;
        public InstructorController(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;

        }
        //public IActionResult CoursesOfDepartment(int dept_Id)
        //{
        //    var crs = context.courses.Where(e => e.Dept_Id == dept_Id).ToList();
        //    return PartialView("_CoursesOfDepartmentPartial", crs);

        //}
        //[Route("inst/{id:int?}")]
        [HttpGet("inst/{id:int?}")]
        public IActionResult Index()
        {
            //ViewData["Dept_List"] = context.departments.ToList();
            return View(_instructorRepository.GetAllInst());
        }
        //public IActionResult DetailPartialView(int id)
        //{
        //    var ins = context.instructors.Find(id);
        //    return PartialView("_DetailPartial", ins);

        //}

        public IActionResult Detail(int Id)
        {
            var ViewById = _instructorRepository.GetById(Id);

            return View(ViewById);
        }

        public IActionResult Edit(int id)
        {
            //ViewData["DeptId"] = context.departments.ToList();
            //ViewData["CourseId"] = context.courses.ToList();
            return View(_instructorRepository.GetById(id));

        }

        [HttpPost]
        public IActionResult SaveEdit(int id, Instructor Inst)
        {
           

            if (ModelState.IsValid)
            {
                _instructorRepository.EditInstructor(id, Inst);
                return RedirectToAction("Index");

            }
            //ViewData["DeptId"] = context.departments.ToList();
            //ViewData["CourseId"] = context.courses.ToList();
            return View("Edit", Inst);


        }

        public IActionResult NewInstructor()
        {
            //ViewData["DeptId"] = context.departments.ToList();
            //ViewData["CourseId"] = context.courses.ToList();
            return View();

        }

        [HttpPost]
        public IActionResult SaveNEW(Instructor Inst)
        {
            //ViewData["DeptId"] = context.departments.ToList();
            //ViewData["CourseId"] = context.courses.ToList();
            if (ModelState.IsValid)
            {

                _instructorRepository.NewInstructor(Inst);
                return RedirectToAction("Index");

            }

            return View("NewInstructor", Inst);
        }

        public IActionResult Delete(int id)
        {
          
            if (ModelState.IsValid)
            {
                _instructorRepository.DeleteInstructor(id);
                
                return RedirectToAction("Index");
            }

            return View("Index");
        }

    }
}
