using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectSite.Models;

namespace PerfectSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ApplicationContext _db;
        private readonly UserManager<User> _userManager;

        public HomeController(IWebHostEnvironment environment, ApplicationContext db, UserManager<User> userManager)
        {
            _environment = environment;
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (User.IsInRole("God of the Site"))
                return View("GodIndex");

            return View();
        }

        [Authorize(Roles = "God of the Site")]
        public async Task<IActionResult> OrderList()
        {
            return View(await _db.Orders.ToListAsync());
        }

        public IActionResult DownloadDocumentation()
        {
            string file_path = Path.Combine(_environment.WebRootPath, "Documentation/Important.png");
            byte[] bytes = System.IO.File.ReadAllBytes(file_path);
            string file_type = "image/png";
            string file_name = "Важная документация.png";
            return File(bytes, file_type, file_name);
        }
    }
}