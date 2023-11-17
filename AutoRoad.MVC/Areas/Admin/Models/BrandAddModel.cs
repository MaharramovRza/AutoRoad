using System.ComponentModel.DataAnnotations;

namespace AutoRoad.MVC.Areas.Admin.Models
{
    public class BrandAddModel
    {
        [Required()]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
