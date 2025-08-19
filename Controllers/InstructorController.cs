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

        public IActionResult Edit(int id)
        {
            ViewData["DeptId"] = context.departments.ToList();
            ViewData["CourseId"] = context.courses.ToList();
            return View(context.instructors.FirstOrDefault(E => E.Id == id));

        }

        public IActionResult SaveEdit(int id, Instructor Inst)
        {
            Instructor OldData = context.instructors.FirstOrDefault(e => e.Id == id);

            if (Inst.Name != null && Inst.Salary != null)
            {
                
                if (OldData != null)
                {
                    OldData.Name = Inst.Name;
                    OldData.Salary = Inst.Salary;
                    OldData.Imag = Inst.Imag;
                    OldData.Address = Inst.Address;
                    OldData.Crs_Id = Inst.Crs_Id;
                    OldData.Dept_Id = Inst.Dept_Id;
                    context.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            ViewData["DeptId"] = context.departments.ToList();
            ViewData["CourseId"] = context.courses.ToList();
            return View("Edit" , Inst);


        }
    }
}
