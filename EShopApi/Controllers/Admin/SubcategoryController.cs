using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.Admin
{
    public class SubcategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
