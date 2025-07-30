using Microsoft.AspNetCore.Cors.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_mvc_iTi.Models
{
    public class Trainee
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Imag { get; set; }
        [Required]
        public string Address { get; set; }
        public double Grade { get; set; }

        [ForeignKey("department")]
        public int Dept_Id { get; set; }
        public Department department { get; set; }

        public List<CrsResult> crsResults { get; set; }

    }
}
