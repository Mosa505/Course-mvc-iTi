using Microsoft.AspNetCore.Cors.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_mvc_iTi.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Course Name")]
        public string Name { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }

        [ForeignKey("department")]
        [Display(Name ="Department Name")]
        public int Dept_Id { get; set; }
        public Department department { get; set; }

        public List<Instructor> Instructors { get; set; }
        public List<CrsResult> crsResults { get; set; }

    }
}
