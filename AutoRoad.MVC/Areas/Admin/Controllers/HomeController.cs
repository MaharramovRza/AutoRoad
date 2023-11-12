using AutoRoad.MVC.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoRoad.MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    [MyAuth("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
     
        
    }
}
