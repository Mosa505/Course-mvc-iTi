using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_mvc_iTi.Models
{
    public class Instructor
    {


        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Imag { get; set; }
        public double Salary { get; set; }
        [Required]
        public string Address { get; set; }

        [ForeignKey("department")]
        public int Dept_Id { get; set; }
        public Department department { get; set; }

        [ForeignKey("course")]
        public int Crs_Id { get; set; }
        public Course course { get; set; }

    }
}
