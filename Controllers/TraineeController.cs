using Course_mvc_iTi.Models;
using Course_mvc_iTi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Course_mvc_iTi.Controllers
{
    public class TraineeController : Controller
    {
        public CourseDbContext context = new CourseDbContext();
        public IActionResult Details(int id)
        {
            var TraineId = context.trainees.FirstOrDefault(x => x.Id == id);
            var TraineGrade = context.trainees.Select(x => x.Grade).ToList();
            var CosName = context.courses.Select(x => x.Name).ToList();
          
            string ColorRed = "Red";
            string ColorGreen = "Green";
            DetailsTraineeScoreViewModel Det = new DetailsTraineeScoreViewModel();

            Det.TraineeId = TraineId.Id;
            Det.TraineeName = TraineId.Name;
            foreach (var Iteam in CosName)
            {
                Det.CourseName = Iteam;
            }
            foreach (var Iteam in TraineGrade)
            {
                 Det.Degree =(int)Iteam;
            
            }
           

            if (Det.Degree > 60)
            {
                Det.Color= ColorGreen;
            }
            else
                Det.Color = ColorRed;


            return View(Det);
        }
    }
}
