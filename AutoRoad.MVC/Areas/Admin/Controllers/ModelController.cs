using Microsoft.AspNetCore.Mvc;

namespace AutoRoad.MVC.Areas.Admin.Controllers
{
    public class ModelController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
