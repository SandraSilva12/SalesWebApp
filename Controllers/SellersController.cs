using Microsoft.AspNetCore.Mvc;

namespace SalesWebMVC2.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
