using Microsoft.AspNetCore.Mvc;

namespace AutoRoad.MVC.Components.Home
{
    public class BannerHomeViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
