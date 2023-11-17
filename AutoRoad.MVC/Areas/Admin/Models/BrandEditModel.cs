using System.ComponentModel.DataAnnotations;

namespace AutoRoad.MVC.Areas.Admin.Models
{
    public class BrandEditModel
    {
        [Required()]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }
        public int BrandId { get; set; }
    }
}
