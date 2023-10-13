using AutoRoad.MVC.Data;
using AutoRoad.MVC.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var user = _context.Users.Where(c => c.Email == request.Email).FirstOrDefault();

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
                new Claim("UserRole",user.UserRole.Name),
                new Claim("UserRoleId",user.UserRoleId.ToString()),
                new Claim("Id",user.Id.ToString())

            };

            var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

            //SignInAsync Funksiyasi,verdiyimiz melumatlari Cookiye gonderir
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                          new ClaimsPrincipal(claimsIdentity));
                                         

            return RedirectToAction("Index","Home");

                
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
            if(!ModelState.IsValid)
            {
                return View(request);   
            }

            return RedirectToAction("Login","Account");
        }
    }
}
