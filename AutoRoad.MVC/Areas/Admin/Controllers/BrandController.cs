using AutoRoad.MVC.ViewModels.Pagination;
using AutoRoad.MVC.Data;
using AutoRoad.MVC.DTOs;
using AutoRoad.MVC.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoRoad.MVC.Areas.Admin.Models;
using AutoRoad.MVC.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Azure.Core;

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

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(BrandAddModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var brands = await _context.Brands.ToListAsync();

            var brand = _context.Brands.Where(c => c.Name.ToLower() ==  request.Name.ToLower()).FirstOrDefault();

            if(brand != null)
            {
                ModelState.AddModelError("","Brand already exists");
                return View(request);

            }

            brand = new Brand();

            brand.Name = request.Name;
            brand.Created = DateTime.Now;
            brand.Updated = DateTime.Now;

            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();

            return RedirectToAction("List","Brand");
        }


        [HttpGet]
        public IActionResult Edit(int brandId)
        {
            var brand = _context.Brands.Where(c => c.Id == brandId)
                                        .Select(c=> new BrandEditModel
                                        {
                                            Name = c.Name,
                                            BrandId = c.Id
                                        })
                                       .FirstOrDefault();

            if(brand == null)
            {
                return RedirectToAction("List", "Brand");
            }


            return View(brand);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BrandEditModel request)
        {
            var brand = await _context.Brands.Where(c => c.Id == request.BrandId)
                                       .FirstOrDefaultAsync();

            if(brand == null)
            {
                ModelState.AddModelError("","There is not any brand like that");
                return View(request);
            }

            var checkBrandName = await _context.Brands.Where(c => c.Name.ToLower() == request.Name.ToLower())
                                                      .FirstOrDefaultAsync();

            if(checkBrandName != null)
            {
                ModelState.AddModelError("", "This brand name already exists");
                return View(request);
            }

            brand.Name = request.Name;
            brand.Updated = DateTime.Now;

            await _context.SaveChangesAsync();

            return RedirectToAction("List", "Brand");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int brandId)
        {
            var brand = await _context.Brands.Where(c => c.Id == brandId)
                                             .FirstOrDefaultAsync();

            if(brand == null)
            {
                return RedirectToAction("List", "Brand");
            }

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();

            return RedirectToAction("List", "Brand");
        }
    }
}
