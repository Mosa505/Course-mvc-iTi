using Course_mvc_iTi.Models;

namespace Course_mvc_iTi.Repository
{
    public interface IInstructorRepository
    {
        IEnumerable<Instructor> GetAllInst();
        Instructor GetById(int id);
        void EditInstructor(int id, Instructor NewInstructor);
        void NewInstructor(Instructor NewInstructor );
        void DeleteInstructor(int id);




    }
}
