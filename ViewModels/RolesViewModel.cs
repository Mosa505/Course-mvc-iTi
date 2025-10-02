using System.ComponentModel.DataAnnotations;

namespace Course_mvc_iTi.ViewModels
{
    public class RolesViewModel
    {
        [Required]
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }

    }
}
