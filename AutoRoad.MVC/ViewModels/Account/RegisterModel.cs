using System.ComponentModel.DataAnnotations;

namespace AutoRoad.MVC.ViewModels.Account
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }

        [EmailAddress(ErrorMessage = "Email is incorrect")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
