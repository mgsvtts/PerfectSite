using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public HomeController(IWebHostEnvironment environment, ApplicationContext db)
        {
            _environment = environment;
        }

        public IActionResult Index()
        {
            if (User.IsInRole("God of the Site"))
                return View("GodIndex");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}