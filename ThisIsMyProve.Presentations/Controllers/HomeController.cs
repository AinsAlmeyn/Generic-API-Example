using Microsoft.AspNetCore.Mvc;

namespace ThisIsMyProve.Presentations.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
