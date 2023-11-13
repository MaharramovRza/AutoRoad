using AutoRoad.MVC.ViewModels.Pagination;
using AutoRoad.MVC.Data;
using AutoRoad.MVC.DTOs;
using AutoRoad.MVC.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoRoad.MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    [MyAuth("Admin")]
    public class BrandController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BrandController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> List(int page = 1) //Optional Parameter
        {
            var brands = await _context.Brands.Select(c => new BrandDto
            {
                BrandId = c.Id,
                Name = c.Name

            }).Skip((page-1)*10).Take(10).ToListAsync();

            var count = await _context.Brands.CountAsync();
            var pageCount = Math.Ceiling(count/ (decimal)10 );

            ViewBag.PaginationModel = new PaginationModel
            {
                Url = "/Admin/Brand/List",
                PageCount = (int)pageCount,
                Page = page
            };

            
            return View(brands);
        }
    }
}
