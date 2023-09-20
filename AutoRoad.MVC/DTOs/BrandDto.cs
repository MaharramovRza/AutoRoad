namespace AutoRoad.MVC.DTOs
{
    public class BrandDto
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public List<ModelDto> Models { get; set; }
    }
}
