using Microsoft.AspNetCore.Identity;

namespace Course_mvc_iTi.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Address { get; set; }

    }
}
