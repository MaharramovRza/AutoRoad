using AutoRoad.MVC.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(option =>
    option.UseSqlServer(builder.Configuration["Database:ConnectionString"])
);

var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute("default",
    "{controller=Home}/{action=Index}");

app.Run();
