using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.Admin
{
    public class ProductTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
