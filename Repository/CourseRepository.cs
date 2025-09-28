using Course_mvc_iTi.Models;

namespace Course_mvc_iTi.Repository
{
    public class CourseRepository : ICourseRepository
    {
        CourseDbContext _Context;
        public CourseRepository(CourseDbContext context)
        {
            _Context = context;
        }

        public void DeleteById(int id)
        {
            Course Crs =GetById(id);
            _Context.courses.Remove(Crs);
            _Context.SaveChanges();

        }

        public IEnumerable<Course> GetAll()
        {
            var Crs = _Context.courses.ToList();
            return Crs;
        }

        public Course GetById(int id)
        {
           Course crs = _Context.courses.Find(id);
            return crs;
        }

        public void Insert(Course newCourse)
        {
            _Context.courses.Add(newCourse);
            _Context.SaveChanges();
        }

        public void Update(int id, Course NewCourse)
        {
           Course crs = GetById(id);
            crs.Name = NewCourse.Name;
            crs.Degree = NewCourse.Degree;
            crs.MinDegree = NewCourse.MinDegree;
            crs.Dept_Id = NewCourse.Dept_Id;
            _Context.SaveChanges();
        }
    }
}
