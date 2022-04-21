using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private ApplicationContext _db;

        public HomeController(IWebHostEnvironment environment, ApplicationContext db)
        {
            _environment = environment;
            _db = db;
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}