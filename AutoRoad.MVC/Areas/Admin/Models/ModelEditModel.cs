using System.ComponentModel.DataAnnotations;

namespace AutoRoad.MVC.Areas.Admin.Models
{
    public class ModelEditModel
    {
        [Required()]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required()]
        [MinLength(3)]
        [MaxLength(20)]
        public string BrandName { get; set; }
        public int ModelId { get; set; }
        public int BrandId { get; set; }
    }
}
