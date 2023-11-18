using AutoRoad.MVC.Areas.Admin.Models;
using AutoRoad.MVC.Data;
using AutoRoad.MVC.DTOs;
using AutoRoad.MVC.Filters;
using AutoRoad.MVC.Models;
using AutoRoad.MVC.ViewModels.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoRoad.MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    [MyAuth("Admin")]
    public class ModelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ModelController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> List(int page = 1)
        {
            var models = await _context.Models
                                 .Include(c => c.Brand)  
                                 .Select(c => new ModelDto
                                        
                                        {
                                            ModelId = c.Id,
                                            BrandId = c.BrandId,
                                            ModelName = c.Name,
                                            BrandName = c.Brand.Name
                                        }).Skip((page - 1) * 10).Take(10).ToListAsync();

            var count = await _context.Models.CountAsync();
            var pageCount = Math.Ceiling(count / (decimal)10);

            ViewBag.PaginationModel = new PaginationModel
            {
                Url = "/Admin/Model/List",
                PageCount = (int)pageCount,
                Page = page
            };

            return View(models);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ModelAddModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var brand = await _context.Brands.Where(c => c.Name.ToLower() == request.BrandName.ToLower())
                                            .FirstOrDefaultAsync();

            if (brand == null)
            {
                ModelState.AddModelError("", "There is not any brand like that");
                return View(request);
            }


            var model = await _context.Models.Include(c => c.Brand)
                                             .Where(c => (c.Name.ToLower() == request.Name.ToLower())
                                                                        &&
                                                         (c.Brand.Name.ToLower() == request.BrandName.ToLower())
                                                   )

                                             .FirstOrDefaultAsync();

            if (model != null)
            {
                ModelState.AddModelError("", "This model already exists");
                return View(request);
            }

            

            model = new Model();
            model.Name = request.Name;
            model.BrandId = brand.Id;

            await _context.Models.AddAsync(model);
            await _context.SaveChangesAsync();


            return RedirectToAction("List", "Model");

        }

        [HttpGet]
        public IActionResult Edit(int modelId)
        {
            var model = _context.Models.Where(c => c.Id == modelId)
                                       .Include(c => c.Brand)
                                       .Select(c => new ModelEditModel
                                        {
                                            Name = c.Name,
                                            BrandName = c.Brand.Name,
                                            BrandId = c.BrandId,
                                            ModelId = c.Id
                                        })
                                       .FirstOrDefault();

            if(model == null)
            {
                return RedirectToAction("List", "Model");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ModelEditModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var model = await _context.Models.Where(c => c.Id == request.ModelId)
                                             .FirstOrDefaultAsync();

            var brand = await _context.Brands.Where(c => c.Name.ToLower() == request.BrandName.ToLower())
                                             .FirstOrDefaultAsync();
            if(model == null)
            {
                ModelState.AddModelError("", "There is not any model like that");
                return View(request);
            }

            if(brand == null)
            {
                ModelState.AddModelError("", "There is not brand model like that");
                return View(request);
            }

            var ckeckModel = await _context.Models.Include(c => c.Brand)
                                             .Where(c => (c.Name.ToLower() == request.Name.ToLower() )
                                                                     &&
                                                         (c.Brand.Name.ToLower() == request.BrandName.ToLower())
                                                   )
                                             .FirstOrDefaultAsync();              
            
            if(ckeckModel != null)
            {
                ModelState.AddModelError("", "This model already exists");
                return View(request);
            }


            model.Name = request.Name;
            model.BrandId = brand.Id;

            await _context.SaveChangesAsync();

            return RedirectToAction("List", "Model");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int modelId)
        {
            var model = await _context.Models.Where(c => c.Id == modelId)
                                       .FirstOrDefaultAsync();

            if(model == null)
            {
                return RedirectToAction("List", "Model");
            }

            _context.Models.Remove(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("List", "Model");
        }
    }
}
