using AutoRoad.MVC.Data;
using AutoRoad.MVC.DTOs;
using AutoRoad.MVC.Models;
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
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            List<BrandDto> brands = await _context
                .Brands
                .Include(b => b.Models)
                .Select(b => new BrandDto
              {
                    Name = b.Name,
                    Models = b.Models
                              .Select(m => new ModelDto
                            {
                                  Name = m.Name,
                                  Photo = m.CarPhotos
                                            .Where(p => p.IsMain == true)
                                            .Select(p => _configuration["Files:Cars"] + p.Name)
                                            .FirstOrDefault()
                            }).ToList()
                              

              }).ToListAsync();

            return View(brands);
        }
    }
}
