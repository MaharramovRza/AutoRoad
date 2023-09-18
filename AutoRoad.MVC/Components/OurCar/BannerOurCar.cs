using Microsoft.AspNetCore.Mvc;

namespace AutoRoad.MVC.Components.OurCar
{
    public class BannerOurCar : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
