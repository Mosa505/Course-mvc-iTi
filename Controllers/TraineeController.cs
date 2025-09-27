using Course_mvc_iTi.Models;
using Course_mvc_iTi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace Course_mvc_iTi.Controllers
{
    public class TraineeController : Controller
    {
        //public CourseDbContext context = new CourseDbContext();
        //public IActionResult Details(int id, int idCourse)
        //{
            
        //    var Trainee = context.crsResults
        //        .Where(E => E.Trainee_Id == id && E.Crs_Id == idCourse)
        //        .Select(E => new DetailsTraineeScoreViewModel
        //        {
        //            TraineeId = E.Trainee_Id,
        //            TraineeName = E.trainee.Name,
        //            CourseName = E.course.Name,
        //            Score = E.Degree


        //        }).FirstOrDefault();
        //    if (Trainee == null)
        //    {
        //        return Content("Have no Data");
        //    }
        //    CookieOptions option = new CookieOptions();
        //    option.Expires = DateTime.Now.AddHours(2);

        //    Response.Cookies.Append("Id",id.ToString());

        //    Trainee.Color = Trainee.Score >= 60 ? "Green" : "Red";

        //    return View(Trainee);
        //}

        //public IActionResult AllDetails()
        //{
        //    var get = Request.Cookies["Id"];

        //    if (get == null)
        //    {
        //        return Content("Have no Data in session");
        //    }
        //    var Result = context.crsResults
        //        .Where(E => E.Trainee_Id == int.Parse(get))
        //        .Select(E => new DetailsTraineeScoreViewModel
        //        {
        //            TraineeId = E.trainee.Id,
        //            TraineeName = E.trainee.Name,
        //            CourseName = E.course.Name,
        //            Score = E.Degree

        //        }).ToList();




        //    foreach (var item in Result)
        //        item.Color = item.Score >= 60 ? "Green" : "Red";

        //    return View(Result);

        //}
    }
}
