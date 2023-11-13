using AutoRoad.MVC.ViewModels.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace AutoRoad.MVC.Areas.Admin.Components
{
    public class PaginationViewComponent : ViewComponent
    {
        public PaginationViewComponent()
        {
            
        }

        public async Task<IViewComponentResult> InvokeAsync(PaginationModel paginationModel)
        {
            return View(paginationModel);
        }

    }
}
