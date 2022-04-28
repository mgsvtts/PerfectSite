using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Data.Products;
using WebApplication1.Models;
using WebApplication1.ViewModels.Home;

namespace WebApplication1.Controllers
{
    public class BuyController : Controller
    {
        private readonly ApplicationContext _db;
        private readonly UserManager<User> _userManager;
        public BuyController(ApplicationContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> CPU_Buy(int cpuId)
        {
            if(cpuId != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    User user = await _userManager.FindByNameAsync(User.Identity.Name);

                    return View(new BuyViewModel { ProductId = cpuId, CreatedAt = DateTime.Now, UserName = user.FirstName});
                }

                return RedirectToAction("Login", "Account");
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CPU_Buy(BuyViewModel model)
        {  
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                Order order = new Order { CreatedAt = model.CreatedAt, ProductId = model.ProductId, UserId = user.Id, Quantity = model.Quantity };
                CPU cpu = await _db.CPUs.FirstOrDefaultAsync(p => p.Id == model.ProductId);
                
                cpu.Amount -= model.Quantity;
                cpu.BoughtTimes += model.Quantity;

                _db.Orders.Add(order);
                _db.CPUs.Update(cpu);
                
                await _db.SaveChangesAsync();
                
                return View("~/Views/Buy/ThanksPage.cshtml", order);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Frame_Buy(int frameId)
        {
            if (frameId != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    User user = await _userManager.FindByNameAsync(User.Identity.Name);

                    return View(new BuyViewModel { ProductId = frameId, CreatedAt = DateTime.Now, UserName = user.FirstName });
                }

                return RedirectToAction("Login", "Account");
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Frame_Buy(BuyViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                Order order = new Order { CreatedAt = model.CreatedAt, ProductId = model.ProductId, UserId = user.Id, Quantity = model.Quantity };
                ComputerFrame frame = await _db.ComputerFrames.FirstOrDefaultAsync(p => p.Id == model.ProductId);

                frame.Amount -= model.Quantity;
                frame.BoughtTimes += model.Quantity;

                _db.Orders.Add(order);
                _db.ComputerFrames.Update(frame);

                await _db.SaveChangesAsync();

                return View("~/Views/Buy/ThanksPage.cshtml", order);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GPU_Buy(int gpuId)
        {
            if (gpuId != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    User user = await _userManager.FindByNameAsync(User.Identity.Name);

                    return View(new BuyViewModel { ProductId = gpuId, CreatedAt = DateTime.Now, UserName = user.FirstName });
                }

                return RedirectToAction("Login", "Account");
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GPU_Buy(BuyViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                Order order = new Order { CreatedAt = model.CreatedAt, ProductId = model.ProductId, UserId = user.Id, Quantity = model.Quantity };
                GPU gpu = await _db.GPUs.FirstOrDefaultAsync(p => p.Id == model.ProductId);

                gpu.Amount -= model.Quantity;
                gpu.BoughtTimes += model.Quantity;

                _db.Orders.Add(order);
                _db.GPUs.Update(gpu);

                await _db.SaveChangesAsync();

                return View("~/Views/Buy/ThanksPage.cshtml", order);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> HDD_Buy(int hddId)
        {
            if (hddId != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    User user = await _userManager.FindByNameAsync(User.Identity.Name);

                    return View(new BuyViewModel { ProductId = hddId, CreatedAt = DateTime.Now, UserName = user.FirstName });
                }

                return RedirectToAction("Login", "Account");
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HDD_Buy(BuyViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                Order order = new Order { CreatedAt = model.CreatedAt, ProductId = model.ProductId, UserId = user.Id, Quantity = model.Quantity };
                HDD hdd = await _db.HDDs.FirstOrDefaultAsync(p => p.Id == model.ProductId);

                hdd.Amount -= model.Quantity;
                hdd.BoughtTimes += model.Quantity;

                _db.Orders.Add(order);
                _db.HDDs.Update(hdd);

                await _db.SaveChangesAsync();

                return View("~/Views/Buy/ThanksPage.cshtml", order);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Motherboard_Buy(int motherboardId)
        {
            if (motherboardId != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    User user = await _userManager.FindByNameAsync(User.Identity.Name);

                    return View(new BuyViewModel { ProductId = motherboardId, CreatedAt = DateTime.Now, UserName = user.FirstName });
                }

                return RedirectToAction("Login", "Account");
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Motherboard_Buy(BuyViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                Order order = new Order { CreatedAt = model.CreatedAt, ProductId = model.ProductId, UserId = user.Id, Quantity = model.Quantity };
                Motherboard motherboard = await _db.Motherboards.FirstOrDefaultAsync(p => p.Id == model.ProductId);

                motherboard.Amount -= model.Quantity;
                motherboard.BoughtTimes += model.Quantity;

                _db.Orders.Add(order);
                _db.Motherboards.Update(motherboard);

                await _db.SaveChangesAsync();

                return View("~/Views/Buy/ThanksPage.cshtml", order);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Phone_Buy(int phoneId)
        {
            if (phoneId != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    User user = await _userManager.FindByNameAsync(User.Identity.Name);

                    return View(new BuyViewModel { ProductId = phoneId, CreatedAt = DateTime.Now, UserName = user.FirstName });
                }

                return RedirectToAction("Login", "Account");
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Phone_Buy(BuyViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                Order order = new Order { CreatedAt = model.CreatedAt, ProductId = model.ProductId, UserId = user.Id, Quantity = model.Quantity };
                Phone phone = await _db.Phones.FirstOrDefaultAsync(p => p.Id == model.ProductId);

                phone.Amount -= model.Quantity;
                phone.BoughtTimes += model.Quantity;

                _db.Orders.Add(order);
                _db.Phones.Update(phone);

                await _db.SaveChangesAsync();

                return View("~/Views/Buy/ThanksPage.cshtml", order);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> PowerSupply_Buy(int powerSupplyId)
        {
            if (powerSupplyId != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    User user = await _userManager.FindByNameAsync(User.Identity.Name);

                    return View(new BuyViewModel { ProductId = powerSupplyId, CreatedAt = DateTime.Now, UserName = user.FirstName });
                }

                return RedirectToAction("Login", "Account");
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PowerSupply_Buy(BuyViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                Order order = new Order { CreatedAt = model.CreatedAt, ProductId = model.ProductId, UserId = user.Id, Quantity = model.Quantity };
                PowerSupply powerSupply = await _db.PowerSupplies.FirstOrDefaultAsync(p => p.Id == model.ProductId);

                powerSupply.Amount -= model.Quantity;
                powerSupply.BoughtTimes += model.Quantity;

                _db.Orders.Add(order);
                _db.PowerSupplies.Update(powerSupply);

                await _db.SaveChangesAsync();

                return View("~/Views/Buy/ThanksPage.cshtml", order);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> RAM_Buy(int ramId)
        {
            if (ramId != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    User user = await _userManager.FindByNameAsync(User.Identity.Name);

                    return View(new BuyViewModel { ProductId = ramId, CreatedAt = DateTime.Now, UserName = user.FirstName });
                }

                return RedirectToAction("Login", "Account");
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RAM_Buy(BuyViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                Order order = new Order { CreatedAt = model.CreatedAt, ProductId = model.ProductId, UserId = user.Id, Quantity = model.Quantity };
                RAM ram = await _db.RAMs.FirstOrDefaultAsync(p => p.Id == model.ProductId);

                ram.Amount -= model.Quantity;
                ram.BoughtTimes += model.Quantity;

                _db.Orders.Add(order);
                _db.RAMs.Update(ram);

                await _db.SaveChangesAsync();

                return View("~/Views/Buy/ThanksPage.cshtml", order);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> SSD_Buy(int ssdId)
        {
            if (ssdId != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    User user = await _userManager.FindByNameAsync(User.Identity.Name);

                    return View(new BuyViewModel { ProductId = ssdId, CreatedAt = DateTime.Now, UserName = user.FirstName });
                }

                return RedirectToAction("Login", "Account");
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SSD_Buy(BuyViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                Order order = new Order { CreatedAt = model.CreatedAt, ProductId = model.ProductId, UserId = user.Id, Quantity = model.Quantity };
                SSD ssd = await _db.SSDs.FirstOrDefaultAsync(p => p.Id == model.ProductId);

                ssd.Amount -= model.Quantity;
                ssd.BoughtTimes += model.Quantity;

                _db.Orders.Add(order);
                _db.SSDs.Update(ssd);

                await _db.SaveChangesAsync();

                return View("~/Views/Buy/ThanksPage.cshtml", order);
            }

            return View(model);
        }
    }
}
