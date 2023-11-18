using System.ComponentModel.DataAnnotations;

namespace AutoRoad.MVC.Areas.Admin.Models
{
    public class UserEditModel
    {
        [Required]
        [MaxLength(20)]
        public string UserRole { get; set; }
        public int UserId { get; set; }
    }
}
