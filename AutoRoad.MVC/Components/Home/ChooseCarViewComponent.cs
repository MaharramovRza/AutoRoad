using AutoRoad.MVC.Data;
using AutoRoad.MVC.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoRoad.MVC.Components.Home
{
    public class ChooseCarViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public ChooseCarViewComponent(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }
        public async Task<IViewComponentResult> InvokeAsync()
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
                                              .Take(8).ToListAsync();


            return View(cars);
        }

    }
}
