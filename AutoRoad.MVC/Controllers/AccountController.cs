using AutoRoad.MVC.Data;
using AutoRoad.MVC.Enums;
using AutoRoad.MVC.Models;
using AutoRoad.MVC.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AutoRoad.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            //IsAuthenticated eger true olsa, o demekdir ki login olub yeni Cookie'de Token movcuddur
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

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

            if (user is null)
            {
                ModelState.AddModelError("", "Email or Password is incorrect");

                return View(request);
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                var buffer = Encoding.UTF8.GetBytes(request.Password);
                var hash = sha256.ComputeHash(buffer);

                if (!user.Password.SequenceEqual(hash)) //SequenceEqual -> her bir massivin indekslerini yoxlayir
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


            return RedirectToAction("Index", "Home");


        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(); //Cookie silinir

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var user = _context.Users.Where(c => c.Email == request.Email).FirstOrDefault();

            if (user is not null)
            {
                ModelState.AddModelError("", "Email is already exists");
                return View(request);
            }

            user = new User();
            user.Name = request.Name;
            user.Surname = request.Surname;
            user.Email = request.Email;
            user.RegisterDate = DateTime.Now;
            user.Phone = "503418919";
            user.UserRoleId = 2;
            user.UserStatusId = (int)UserStatus.Active;
            user.Created = DateTime.Now;
            user.Updated = DateTime.Now;




            using (SHA256 sha256 = SHA256.Create())
            {
                var buffer = Encoding.UTF8.GetBytes(request.Password);

                var hash = sha256.ComputeHash(buffer);
                user.Password = hash;
            }

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();


            return RedirectToAction("Login", "Account");
        }
    }
}
