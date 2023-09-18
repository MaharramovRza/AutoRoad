using Microsoft.AspNetCore.Mvc;

namespace AutoRoad.MVC.Controllers
{
    public class OurCarController : Controller
    {
        public async Task<IActionResult> List()
        {
            return View();
        }
    }
}
