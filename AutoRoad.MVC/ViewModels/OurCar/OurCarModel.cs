using AutoRoad.MVC.DTOs;

namespace AutoRoad.MVC.ViewModels.OurCar
{
    public class OurCarModel
    {
        public List<CarDto> Cars { get; set; }
        public string Url { get; set; }
        public int Page { get; set; }
        public int PageCount { get; set; }
    }
}
