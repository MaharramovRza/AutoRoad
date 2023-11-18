using AutoRoad.MVC.Areas.Admin.Models;
using AutoRoad.MVC.Data;
using AutoRoad.MVC.DTOs;
using AutoRoad.MVC.Filters;
using AutoRoad.MVC.ViewModels.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoRoad.MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    [MyAuth("Admin")]
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public CarController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }

        [HttpGet]
        public async Task<IActionResult> List(int page = 1)
        {
            var cars = await _context.Cars.Include(c => c.Model)
                                          .ThenInclude(c => c.Brand)
                                          .Include(c => c.Fuel)
                                          .Include(c => c.Transmission)
                                          .Include(c => c.Ban)
                                          .Include(c => c.CarPhotos)
                                          .Select(c => new CarAdminDto
                                          {
                                              CarId = c.Id,
                                              ModelName = c.Model.Name,
                                              BrandName = c.Model.Brand.Name,
                                              FuelType = c.Fuel.Name,
                                              TransmissionType = c.Transmission.Name,
                                              BanType = c.Ban.Name,
                                              HasGarage = c.HasGarage,
                                              Photo = c.CarPhotos
                                                          .Select(p => _configuration["Files:Cars"] + p.Name)
                                                          .FirstOrDefault(),
                                              Price = c.Price,
                                              Year = c.Year,


                                          })
                                          .Skip((page-1)*10)
                                          .Take(10)
                                          .ToListAsync();

            var count = await _context.Cars.CountAsync();
            var pageCount = Math.Ceiling(count / (decimal)10);

            ViewBag.PaginationModel = new PaginationModel
            {
                Url = "/admin/Car/List",
                PageCount = (int)pageCount,
                Page = page
            };


            return View(cars);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var brands = await _context.Brands.Select(c=>new BrandDto
                                               {
                                                        BrandId = c.Id,
                                                        Name = c.Name,
                                                })
                                              .ToListAsync();

            var models = await _context.Models.Select(c=>new ModelDto
                                                {
                                                    ModelId = c.Id,
                                                    ModelName = c.Name
                                                })
                                               .ToListAsync();
            var fuels = await _context.Fuels.Select(c => new FuelDto
            {
                FuelId = c.Id,
                FuelType = c.Name
            }).ToListAsync();

            var bans = await _context.Bans.Select(c => new BanDto
            {
                BanId = c.Id,
                BanType = c.Name
            }).ToListAsync();

            var transmissions = await  _context.Transmissions.Select(c => new TransmissionDto
            {
                TransmissionId = c.Id,
                TransmissionType = c.Name
            }).ToListAsync();

            var vm = new CarAddModel();
            vm.Brands = brands;
            vm.Models = models;
            vm.FuelTypes = fuels;
            vm.BanTypes = bans;
            vm.TransmissionTypes = transmissions;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarAddModel request)
        {
            

            return View();
        }
    }
}
