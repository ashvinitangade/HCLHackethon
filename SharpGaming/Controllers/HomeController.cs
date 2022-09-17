using Microsoft.AspNetCore.Mvc;

namespace SharpGaming.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
