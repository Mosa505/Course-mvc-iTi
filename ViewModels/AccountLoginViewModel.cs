using System.ComponentModel.DataAnnotations;

namespace Course_mvc_iTi.ViewModels
{
    public class AccountLoginViewModel
    {
        [Required]
      
        public string Name{ get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }



    }
}
