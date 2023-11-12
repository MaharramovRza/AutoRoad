using AutoRoad.MVC.Data;
using AutoRoad.MVC.Enums;
using AutoRoad.MVC.ViewModels.Account;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace AutoRoad.MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AccountController : Controller
    {

        private readonly ApplicationDbContext _context;
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var user = await _context.Users.Where(c => c.Email == request.Email)
                                     .Include(c => c.UserRole)
                                     .FirstOrDefaultAsync(); 


            if(user == null)
            {
                ModelState.AddModelError("","Email or Password is incorrect");
                return View(request);
            }

            if(user.UserRoleId != (int)UserRoleEnum.Admin)
            {
                ModelState.AddModelError("","You don't have an access to enter the system");
                return View(request);
            }

            using(SHA256 sha256 = SHA256.Create())
            {
                var buffer = Encoding.UTF8.GetBytes(request.Password);
                var hash = sha256.ComputeHash(buffer);

                if (!user.Password.SequenceEqual(hash))
                {
                    ModelState.AddModelError("", "Email or Password is incorrect");

                    return View(request);
                }
            }

            //Claims
            var claims = new List<Claim>
            {
                new Claim("Name",user.Name),
                new Claim("Surname",user.Surname),
                new Claim("UserRole",user.UserRole.Name)

            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            //SignInAsync Funksiyasi,verdiyimiz melumatlari Cookiye gonderir
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                          new ClaimsPrincipal(claimsIdentity));


            return RedirectToAction("Index","Home");
        } 
    }
}
