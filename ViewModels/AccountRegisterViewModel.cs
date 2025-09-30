using System.ComponentModel.DataAnnotations;

namespace Course_mvc_iTi.ViewModels
{
    public class AccountRegisterViewModel
    {
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Address { get; set; }

    }
}
