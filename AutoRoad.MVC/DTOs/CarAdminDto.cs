namespace AutoRoad.MVC.DTOs
{
    public class CarAdminDto
    {
        public int CarId { get; set; }
        public decimal Price { get; set; }
        public string ModelName { get; set; }
        public string BrandName { get; set; }
        public string FuelType { get; set; }
        public string TransmissionType { get; set; }
        public string BanType { get; set; }
        public int Seats { get; set; }
        public int Doors { get; set; }
        public int Count { get; set; }
        public string Photo { get; set; }
        public int Year { get; set; }
        public bool HasGarage { get; set; }
        public DateTime Created { get; set; }
        public int? Discount { get; set; }
    }
}
