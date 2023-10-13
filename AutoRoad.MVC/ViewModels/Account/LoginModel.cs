using System.ComponentModel.DataAnnotations;

namespace AutoRoad.MVC.ViewModels.Account
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email field is required.")]
        [EmailAddress(ErrorMessage ="Email field is incorrect.")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is required ")]
        public string Password { get; set; }
    }
}
