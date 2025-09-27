using Course_mvc_iTi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;

namespace Course_mvc_iTi.Repository
{

    // CRUD Operation Model 
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
        void DeleteById(int id);
        void Update(int id, Course NewCourse);
        void Insert (Course newCourse);
        Course GetById (int id);
    }
}
