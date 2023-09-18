using Microsoft.AspNetCore.Mvc;

namespace AutoRoad.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
