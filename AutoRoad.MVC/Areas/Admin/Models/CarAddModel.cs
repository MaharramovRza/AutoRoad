using AutoRoad.MVC.DTOs;
using AutoRoad.MVC.Models;

namespace AutoRoad.MVC.Areas.Admin.Models
{
    public class CarAddModel
    {
        public int CarId { get; set; }
        public decimal Price { get; set; }
        public List<ModelDto> Models { get; set; }
        public List<BrandDto> Brands { get; set; }
        public List<FuelDto> FuelTypes { get; set; }
        public List<TransmissionDto> TransmissionTypes { get; set; }
        public List<BanDto> BanTypes { get; set; }
        public int Seats { get; set; }
        public int Doors { get; set; }
        public int Count { get; set; }
        public string Photo { get; set; }
        public int Year { get; set; }
        public bool HasGarage { get; set; }
        public bool IsMain { get; set; }
    }
}
