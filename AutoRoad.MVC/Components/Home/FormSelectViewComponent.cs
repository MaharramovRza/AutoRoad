using AutoRoad.MVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace AutoRoad.MVC.Components.Home
{
    public class FormSelectViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public FormSelectViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            

            return View();
        }
    }
}
