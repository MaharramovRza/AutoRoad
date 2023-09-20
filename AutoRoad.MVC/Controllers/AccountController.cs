using Microsoft.AspNetCore.Mvc;

namespace AutoRoad.MVC.Controllers
{
    public class AccountController : Controller
    {
        public async Task<IActionResult> Login()
        {
            return View();
        }
    }
}
