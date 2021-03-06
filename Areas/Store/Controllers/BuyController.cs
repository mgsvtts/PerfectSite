using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectSite.Areas.Store.ViewModels;
using PerfectSite.Data.Products;
using PerfectSite.Models;

namespace PerfectSite.Areas.Store.Controllers
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
        public async Task<IActionResult> CPU_Buy(Guid cpuId)
        {
            if (cpuId != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    User user = await _userManager.FindByNameAsync(User.Identity.Name);

                    return View("~/Areas/Store/Views/Buy/CPU_Buy.cshtml", new BuyViewModel { ProductId = cpuId, CreatedAt = DateTime.Now, UserName = user.FirstName });
                }

                return RedirectToAction("Login", "Account", new { area = "Account" });
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CPU_Buy(BuyViewModel model)
        {
            CPU cpu = await _db.CPUs.FirstOrDefaultAsync(p => p.Id == model.ProductId);
            if (cpu.Amount < model.Quantity)
            {
                ModelState.AddModelError("Quantity", "На складе недостаточно товаров");
                return View("~/Areas/Store/Views/Buy/CPU_Buy.cshtml", model);
            }

            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                Order order = new Order { CreatedAt = model.CreatedAt, ProductId = model.ProductId, UserId = user.Id, Quantity = model.Quantity };
                cpu.Amount -= model.Quantity;
                cpu.BoughtTimes += model.Quantity;

                _db.Orders.Add(order);
                _db.CPUs.Update(cpu);

                await _db.SaveChangesAsync();

                return View("~/Areas/Store/Views/Buy/ThanksPage.cshtml", order);
            }

            return View("~/Areas/Store/Views/Buy/CPU_Buy.cshtml", model);
        }

        [HttpGet]
        public async Task<IActionResult> Frame_Buy(Guid frameId)
        {
            if (frameId != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    User user = await _userManager.FindByNameAsync(User.Identity.Name);

                    return View("~/Areas/Store/Views/Buy/Frame_Buy.cshtml", new BuyViewModel { ProductId = frameId, CreatedAt = DateTime.Now, UserName = user.FirstName });
                }

                return RedirectToAction("Login", "Account", new { area = "Account" });
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Frame_Buy(BuyViewModel model)
        {
            ComputerFrame frame = await _db.ComputerFrames.FirstOrDefaultAsync(p => p.Id == model.ProductId);
            if (frame.Amount < model.Quantity)
            {
                ModelState.AddModelError("Quantity", "На складе недостаточно товаров");
                return View("~/Areas/Store/Views/Buy/Frame_Buy.cshtml", model);
            }
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                Order order = new Order { CreatedAt = model.CreatedAt, ProductId = model.ProductId, UserId = user.Id, Quantity = model.Quantity };

                frame.Amount -= model.Quantity;
                frame.BoughtTimes += model.Quantity;

                _db.Orders.Add(order);
                _db.ComputerFrames.Update(frame);

                await _db.SaveChangesAsync();

                return View("~/Areas/Store/Views/Buy/ThanksPage.cshtml", order);
            }

            return View("~/Areas/Store/Views/Buy/Frame_Buy.cshtml", model);
        }

        [HttpGet]
        public async Task<IActionResult> GPU_Buy(Guid gpuId)
        {
            if (gpuId != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    User user = await _userManager.FindByNameAsync(User.Identity.Name);

                    return View("~/Areas/Store/Views/Buy/GPU_Buy.cshtml", new BuyViewModel { ProductId = gpuId, CreatedAt = DateTime.Now, UserName = user.FirstName });
                }

                return RedirectToAction("Login", "Account", new { area = "Account" });
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GPU_Buy(BuyViewModel model)
        {
            GPU gpu = await _db.GPUs.FirstOrDefaultAsync(p => p.Id == model.ProductId);
            if (gpu.Amount < model.Quantity)
            {
                ModelState.AddModelError("Quantity", "На складе недостаточно товаров");
                return View("~/Areas/Store/Views/Buy/GPU_Buy.cshtml", model);
            }
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                Order order = new Order { CreatedAt = model.CreatedAt, ProductId = model.ProductId, UserId = user.Id, Quantity = model.Quantity };

                gpu.Amount -= model.Quantity;
                gpu.BoughtTimes += model.Quantity;

                _db.Orders.Add(order);
                _db.GPUs.Update(gpu);

                await _db.SaveChangesAsync();

                return View("~/Areas/Store/Views/Buy/ThanksPage.cshtml", order);
            }

            return View("~/Areas/Store/Views/Buy/GPU_Buy.cshtml", model);
        }

        [HttpGet]
        public async Task<IActionResult> HDD_Buy(Guid hddId)
        {
            if (hddId != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    User user = await _userManager.FindByNameAsync(User.Identity.Name);

                    return View("~/Areas/Store/Views/Buy/HDD_Buy.cshtml", new BuyViewModel { ProductId = hddId, CreatedAt = DateTime.Now, UserName = user.FirstName });
                }

                return RedirectToAction("Login", "Account", new { area = "Account" });
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HDD_Buy(BuyViewModel model)
        {
            HDD hdd = await _db.HDDs.FirstOrDefaultAsync(p => p.Id == model.ProductId);
            if (hdd.Amount < model.Quantity)
            {
                ModelState.AddModelError("Quantity", "На складе недостаточно товаров");
                return View("~/Areas/Store/Views/Buy/HDD_Buy.cshtml", model);
            }
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                Order order = new Order { CreatedAt = model.CreatedAt, ProductId = model.ProductId, UserId = user.Id, Quantity = model.Quantity };

                hdd.Amount -= model.Quantity;
                hdd.BoughtTimes += model.Quantity;

                _db.Orders.Add(order);
                _db.HDDs.Update(hdd);

                await _db.SaveChangesAsync();

                return View("~/Areas/Store/Views/Buy/ThanksPage.cshtml", order);
            }

            return View("~/Areas/Store/Views/Buy/HDD_Buy.cshtml", model);
        }

        [HttpGet]
        public async Task<IActionResult> Motherboard_Buy(Guid motherboardId)
        {
            if (motherboardId != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    User user = await _userManager.FindByNameAsync(User.Identity.Name);

                    return View("~/Areas/Store/Views/Buy/Motherboard_Buy.cshtml", new BuyViewModel { ProductId = motherboardId, CreatedAt = DateTime.Now, UserName = user.FirstName });
                }

                return RedirectToAction("Login", "Account", new { area = "Account" });
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Motherboard_Buy(BuyViewModel model)
        {
            Motherboard motherboard = await _db.Motherboards.FirstOrDefaultAsync(p => p.Id == model.ProductId);
            if (motherboard.Amount < model.Quantity)
            {
                ModelState.AddModelError("Quantity", "На складе недостаточно товаров");
                return View("~/Areas/Store/Views/Buy/Motherboard_Buy.cshtml", model);
            }
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                Order order = new Order { CreatedAt = model.CreatedAt, ProductId = model.ProductId, UserId = user.Id, Quantity = model.Quantity };

                motherboard.Amount -= model.Quantity;
                motherboard.BoughtTimes += model.Quantity;

                _db.Orders.Add(order);
                _db.Motherboards.Update(motherboard);

                await _db.SaveChangesAsync();

                return View("~/Areas/Store/Views/Buy/ThanksPage.cshtml", order);
            }

            return View("~/Areas/Store/Views/Buy/Motherboard_Buy.cshtml", model);
        }

        [HttpGet]
        public async Task<IActionResult> Phone_Buy(Guid phoneId)
        {
            if (phoneId != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    User user = await _userManager.FindByNameAsync(User.Identity.Name);

                    return View("~/Areas/Store/Views/Buy/Phone_Buy.cshtml", new BuyViewModel { ProductId = phoneId, CreatedAt = DateTime.Now, UserName = user.FirstName });
                }

                return RedirectToAction("Login", "Account", new { area = "Account" });
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Phone_Buy(BuyViewModel model)
        {
            Phone phone = await _db.Phones.FirstOrDefaultAsync(p => p.Id == model.ProductId);
            if (phone.Amount < model.Quantity)
            {
                ModelState.AddModelError("Quantity", "На складе недостаточно товаров");
                return View("~/Areas/Store/Views/Buy/Phone_Buy.cshtml", model);
            }
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                Order order = new Order { CreatedAt = model.CreatedAt, ProductId = model.ProductId, UserId = user.Id, Quantity = model.Quantity };

                phone.Amount -= model.Quantity;
                phone.BoughtTimes += model.Quantity;

                _db.Orders.Add(order);
                _db.Phones.Update(phone);

                await _db.SaveChangesAsync();

                return View("~/Areas/Store/Views/Buy/ThanksPage.cshtml", order);
            }

            return View("~/Areas/Store/Views/Buy/Phone_Buy.cshtml", model);
        }

        [HttpGet]
        public async Task<IActionResult> PowerSupply_Buy(Guid powerSupplyId)
        {
            if (powerSupplyId != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    User user = await _userManager.FindByNameAsync(User.Identity.Name);

                    return View("~/Areas/Store/Views/Buy/PowerSupply_Buy.cshtml", new BuyViewModel { ProductId = powerSupplyId, CreatedAt = DateTime.Now, UserName = user.FirstName });
                }

                return RedirectToAction("Login", "Account", new { area = "Account" });
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PowerSupply_Buy(BuyViewModel model)
        {
            PowerSupply powerSupply = await _db.PowerSupplies.FirstOrDefaultAsync(p => p.Id == model.ProductId);
            if (powerSupply.Amount < model.Quantity)
            {
                ModelState.AddModelError("Quantity", "На складе недостаточно товаров");
                return View("~/Areas/Store/Views/Buy/PowerSupply_Buy.cshtml", model);
            }
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                Order order = new Order { CreatedAt = model.CreatedAt, ProductId = model.ProductId, UserId = user.Id, Quantity = model.Quantity };

                powerSupply.Amount -= model.Quantity;
                powerSupply.BoughtTimes += model.Quantity;

                _db.Orders.Add(order);
                _db.PowerSupplies.Update(powerSupply);

                await _db.SaveChangesAsync();

                return View("~/Areas/Store/Views/Buy/ThanksPage.cshtml", order);
            }

            return View("~/Areas/Store/Views/Buy/PowerSupply_Buy.cshtml", model);
        }

        [HttpGet]
        public async Task<IActionResult> RAM_Buy(Guid ramId)
        {
            if (ramId != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    User user = await _userManager.FindByNameAsync(User.Identity.Name);

                    return View("~/Areas/Store/Views/Buy/RAM_Buy.cshtml", new BuyViewModel { ProductId = ramId, CreatedAt = DateTime.Now, UserName = user.FirstName });
                }

                return RedirectToAction("Login", "Account", new { area = "Account" });
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RAM_Buy(BuyViewModel model)
        {
            RAM ram = await _db.RAMs.FirstOrDefaultAsync(p => p.Id == model.ProductId);
            if (ram.Amount < model.Quantity)
            {
                ModelState.AddModelError("Quantity", "На складе недостаточно товаров");
                return View("~/Areas/Store/Views/Buy/RAM_Buy.cshtml", model);
            }
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                Order order = new Order { CreatedAt = model.CreatedAt, ProductId = model.ProductId, UserId = user.Id, Quantity = model.Quantity };

                ram.Amount -= model.Quantity;
                ram.BoughtTimes += model.Quantity;

                _db.Orders.Add(order);
                _db.RAMs.Update(ram);

                await _db.SaveChangesAsync();

                return View("~/Areas/Store/Views/Buy/ThanksPage.cshtml", order);
            }

            return View("~/Areas/Store/Views/Buy/RAM_Buy.cshtml", model);
        }

        [HttpGet]
        public async Task<IActionResult> SSD_Buy(Guid ssdId)
        {
            if (ssdId != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    User user = await _userManager.FindByNameAsync(User.Identity.Name);

                    return View("~/Areas/Store/Views/Buy/SSD_Buy.cshtml", new BuyViewModel { ProductId = ssdId, CreatedAt = DateTime.Now, UserName = user.FirstName });
                }

                return RedirectToAction("Login", "Account", new { area = "Account" });
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SSD_Buy(BuyViewModel model)
        {
            SSD ssd = await _db.SSDs.FirstOrDefaultAsync(p => p.Id == model.ProductId);
            if (ssd.Amount < model.Quantity)
            {
                ModelState.AddModelError("Quantity", "На складе недостаточно товаров");
                return View("~/Areas/Store/Views/Buy/SSD_Buy.cshtml", model);
            }
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                Order order = new Order { CreatedAt = model.CreatedAt, ProductId = model.ProductId, UserId = user.Id, Quantity = model.Quantity };

                ssd.Amount -= model.Quantity;
                ssd.BoughtTimes += model.Quantity;

                _db.Orders.Add(order);
                _db.SSDs.Update(ssd);

                await _db.SaveChangesAsync();

                return View("~/Areas/Store/Views/Buy/ThanksPage.cshtml", order);
            }

            return View("~/Areas/Store/Views/Buy/SSD_Buy.cshtml", model);
        }

        [HttpGet]
        public async Task<IActionResult> Computer_Buy(Guid ComputerId)
        {
            if (ComputerId != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    User user = await _userManager.FindByNameAsync(User.Identity.Name);

                    return View("~/Areas/Store/Views/Buy/Computer_Buy.cshtml", new BuyViewModel { ProductId = ComputerId, CreatedAt = DateTime.Now, UserName = user.FirstName });
                }

                return RedirectToAction("Login", "Account", new { area = "Account" });
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Computer_Buy(BuyViewModel model)
        {
            Computer computer = await _db.Computers.FirstOrDefaultAsync(p => p.Id == model.ProductId);
            if (computer.Amount < model.Quantity)
            {
                ModelState.AddModelError("Quantity", "На складе недостаточно товаров");
                return View("~/Areas/Store/Views/Buy/Computer_Buy.cshtml", model);
            }
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                Order order = new Order { CreatedAt = model.CreatedAt, ProductId = model.ProductId, UserId = user.Id, Quantity = model.Quantity };

                computer.Amount -= model.Quantity;
                computer.BoughtTimes += model.Quantity;

                _db.Orders.Add(order);
                _db.Computers.Update(computer);

                await _db.SaveChangesAsync();

                return View("~/Areas/Store/Views/Buy/ThanksPage.cshtml", order);
            }

            return View("~/Areas/Store/Views/Buy/Computer_Buy.cshtml", model);
        }
    }
}