using Microsoft.AspNetCore.Mvc;

namespace LearningSupportSystemAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}