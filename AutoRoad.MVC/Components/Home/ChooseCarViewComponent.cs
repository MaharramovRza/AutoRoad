using Microsoft.AspNetCore.Mvc;

namespace AutoRoad.MVC.Components.Home
{
    public class ChooseCarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }

    }
}
