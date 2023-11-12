using AutoRoad.MVC.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

//Authentication'in cookie ile olacagini teyin etdik
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(option =>
    option.UseSqlServer(builder.Configuration["Database:ConnectionString"])
);

var app = builder.Build();
app.UseStaticFiles();

app.MapControllerRoute(name: "admin",
                       pattern: "{area:exists}/{controller=Home}/{action=Index}");

app.MapControllerRoute("default",
    "{controller=Home}/{action=Index}");




//Authentication and Authorization
app.UseAuthentication();
app.UseAuthorization();

app.Run();



