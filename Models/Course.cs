using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_mvc_iTi.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Have No Name")]
        [MaxLength(10)]
        [MinLength(2)]
        [Display(Name = "Course Name")]
        public string Name { get; set; }
        [Required]
        [Range(50, 100)]
        public int Degree { get; set; }
        [Remote("MinDegree" , "Course" , AdditionalFields ="Degree" , ErrorMessage ="MinDegree > Degree")]
        public int MinDegree { get; set; }

        [ForeignKey("department")]
        [Display(Name = "Department Name")]
        public int Dept_Id { get; set; }
        public Department department { get; set; }

        public List<Instructor> Instructors { get; set; }
        public List<CrsResult> crsResults { get; set; }

    }
}
