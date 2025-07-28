using Microsoft.EntityFrameworkCore;

namespace Course_mvc_iTi.Models
{
    public class CourseDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = . ; Database = CourseDb ; Trusted_Connection = true ");
        }


        public DbSet<Department> departments { get; set; }
        public DbSet<Instructor> instructors { get; set; }
        public DbSet<Trainee> trainees { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<CrsResult> crsResults { get; set; }

    }
}




