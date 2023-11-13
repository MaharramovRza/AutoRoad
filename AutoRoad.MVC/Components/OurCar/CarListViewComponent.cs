using AutoRoad.MVC.Data;
using AutoRoad.MVC.DTOs;
using AutoRoad.MVC.Models;
using AutoRoad.MVC.ViewModels.OurCar;
using AutoRoad.MVC.ViewModels.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoRoad.MVC.Components.OurCar
{
    public class CarListViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public CarListViewComponent(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }
        public async Task<IViewComponentResult> InvokeAsync(int page)
        {

            List<CarDto> cars = await _context.Cars
                                              .Include(c => c.Ban)
                                              .Include(c => c.Fuel)
                                              .Include(c => c.Transmission)
                                              .Include(c => c.Model)
                                              .ThenInclude(c => c.Brand)
                                              .Select(c => new CarDto
                                              {
                                                  CarId = c.Id,
                                                  ModelName = c.Model.Name,
                                                  BrandName = c.Model.Brand.Name,
                                                  Photo = c.CarPhotos
                                                           .Where(p => p.IsMain == true)                                                         
                                                           .Select(p => _configuration["Files:Cars"] + p.Name)
                                                           .FirstOrDefault()

                                              })
                                              .Skip((page-1)*8).Take(8).ToListAsync();

            var count = await _context.Cars.CountAsync();
            var pageCount = Math.Ceiling(count / (decimal)8);

            var carModel = new OurCarModel
            {
                Cars = cars,
                Url = "/OurCar/List",
                Page = page,
                PageCount = (int)pageCount
            };

            return View(carModel);
        }
    }
}
