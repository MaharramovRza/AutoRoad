using AutoRoad.MVC.Data;
using AutoRoad.MVC.DTOs;
using AutoRoad.MVC.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AutoRoad.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetCar(int id)
        {
            try
            {
                CarDto result = await _context.Cars
                                              .Where(c => c.Id == id)
                                              .Select(c => new CarDto
                                              {
                                                  ModelName = c.Model.Name,
                                                  BrandName = c.Model.Brand.Name,
                                                  FuelType = c.Fuel.Name,
                                                  BanType = c.Ban.Name,
                                                  TransmissionType = c.Transmission.Name,
                                                  Price = c.Price,
                                                  GarageStatusId = (int)CarStatus.Active,
                                                  Photo = c.CarPhotos
                                                          .Select(p => _configuration["Files:Cars"] + p.Name)
                                                          .FirstOrDefault()

                                              }).FirstOrDefaultAsync();
                if (result == null)
                {
                    return Json(new { status = HttpStatusCode.NotFound });
                }

                return Json(new { status = HttpStatusCode.OK, data = result });
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes.
                // You can also return an appropriate error response here.
                return Json(new { status = HttpStatusCode.InternalServerError, error = ex.Message });
            };
        }
    }
}
