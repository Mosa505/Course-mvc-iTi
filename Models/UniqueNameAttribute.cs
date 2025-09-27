using System.ComponentModel.DataAnnotations;

namespace Course_mvc_iTi.Models
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        //protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        //{
        //    string name = value.ToString();
        //    CourseDbContext context = new CourseDbContext();
        //    Course crs = context.courses.FirstOrDefault(E => E.Name == name );
        //    if (crs == null)
        //    {
        //        return ValidationResult.Success;
        //    }
        //    return new ValidationResult("This Name Not Unique");


        //}

    }
}
