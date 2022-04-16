using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _environment;
        private ApplicationContext _db;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment, ApplicationContext db)
        {
            _logger = logger;
            _environment = environment;
            _db = db;
        }

        [Route("/")]
        [Route("[controller]/[action]")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("[controller]/[action]")]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [Route("[controller]/[action]")]
        public IActionResult Registration()
        {
            return View("RegistrationGet");
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> Registration(User newUser)
        {
            _db.Users.Add(newUser);
            await _db.SaveChangesAsync();
            return View("RegistrationPost");
        }
    }
}