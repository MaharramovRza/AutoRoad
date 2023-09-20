using System.Globalization;

namespace AutoRoad.MVC.DTOs
{
    public class CarDto
    {
        public int ModelId { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        public string Fuel { get; set; }
        public string Ban { get; set; }
        public string Transmission { get; set; }
        public string Doors { get; set; }
        public string Seats { get; set; }

    }
}
