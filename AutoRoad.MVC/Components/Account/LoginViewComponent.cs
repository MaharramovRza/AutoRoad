using Microsoft.AspNetCore.Mvc;

namespace AutoRoad.MVC.Components.Account
{
    public class LoginViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
