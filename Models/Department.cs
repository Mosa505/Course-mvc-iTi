using System.ComponentModel.DataAnnotations;

namespace Course_mvc_iTi.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Manager { get; set; }

        public List<Instructor> instructors { get; set; }
        public List<Trainee> trainees { get; set; }
        public List<Course> courses { get; set; }
    }
}
