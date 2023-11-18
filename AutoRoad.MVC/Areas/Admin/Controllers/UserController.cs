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
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> List(int page = 1)
        {
            var users = await _context.Users.Include(c => c.UserRole)
                                            .Select(c => new UserDto
                                            {
                                                UserId = c.Id,
                                                Name = c.Name,
                                                Surname = c.Surname,
                                                UserRole = c.UserRole.Name
                                            })
                                            .Skip((page - 1) * 10)
                                            .Take(10)
                                            .ToListAsync();

            var count = await _context.Users.CountAsync();
            var pageCount = Math.Ceiling(count / (decimal)10);

            ViewBag.PaginationModel = new PaginationModel
            {
                Url = "/Admin/User/List",
                PageCount = (int)pageCount,
                Page = page
            };


            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int userId)
        {
            var user = await _context.Users.Where(c => c.Id == userId)
                                      .Include(c => c.UserRole)
                                      .Select(c => new UserEditModel
                                      {
                                          UserId = c.Id,
                                          UserRole = c.UserRole.Name
                                      })
                                      .FirstOrDefaultAsync();

            if(user == null)
            {
                return RedirectToAction("List", "User");
            }            
            
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditModel request)
        {
            if(!ModelState.IsValid)
            {
                return View(request);
            }
            
            var user = await _context.Users.Where(c => c.Id == request.UserId)
                                           .FirstOrDefaultAsync();

            if(user == null)
            {
                return RedirectToAction("List", "User");
            }

            user.UserRole.Name = request.UserRole;

            await _context.SaveChangesAsync();

            return RedirectToAction("List", "User");
        }

        //[HttpGet]
        //public async Task<IActionResult> Delete(int userId)
        //{
        //    var user = await _context.Users.Where(c => c.Id == userId)
        //                                   .FirstOrDefaultAsync();

        //    if(user == null)
        //    {
        //        return RedirectToAction("List", "User");
        //    }

        //    _context.Users.Remove(user);
        //    await _context.SaveChangesAsync();

        //    return RedirectToAction("List", "User");
        //}
    }
}
