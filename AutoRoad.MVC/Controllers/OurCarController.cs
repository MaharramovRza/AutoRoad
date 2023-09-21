
using AutoRoad.MVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AutoRoad.MVC.Controllers
{
    public class OurCarController : Controller
    {
        private readonly ApplicationDbContext _context;


        public OurCarController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> List()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetCar(int id)
        {
            var result = await _context.Cars.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (result == null)
                return Json(new { status = HttpStatusCode.NotFound });
            return Json(new { status = HttpStatusCode.OK, data = result });
        }
    }
}
