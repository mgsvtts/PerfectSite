using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.VirtualClasses;
using WebApplication1.Models;

namespace WebApplication1.Controllers
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
    }
}