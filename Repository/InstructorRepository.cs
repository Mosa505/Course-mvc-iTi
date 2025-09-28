using Course_mvc_iTi.Models;

namespace Course_mvc_iTi.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        CourseDbContext _context;
        public InstructorRepository(CourseDbContext context)
        {
            _context = context;
        }
        public void DeleteInstructor(int id)
        {
            var inst = GetById(id);
            _context.instructors.Remove(inst);
            _context.SaveChanges();
        }
        public void EditInstructor(int id, Instructor NewInstructor)
        {
            var OldInst = GetById(id);
            OldInst.Name = NewInstructor.Name;
            OldInst.Salary = NewInstructor.Salary;
            OldInst.Imag = NewInstructor.Imag;
            OldInst.Address = NewInstructor.Address;
            OldInst.Dept_Id = NewInstructor.Dept_Id;
            OldInst.Crs_Id = NewInstructor.Crs_Id;
            _context.SaveChanges();
        }
        public IEnumerable<Instructor> GetAllInst()
        {
            return _context.instructors.ToList();
        }
        public Instructor GetById(int id)
        {
            var inst = _context.instructors.Find(id);
            return inst;
        }
        public void NewInstructor(Instructor NewInstructor)
        {
            _context.instructors.Add(NewInstructor);
            _context.SaveChanges();
        }
    }
}
