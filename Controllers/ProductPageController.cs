using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Products;

namespace WebApplication1.Controllers
{
    public class ProductPageController : Controller
    {
        private readonly ApplicationContext _db;

        public ProductPageController(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> CPUPage(int? id)
        {
            CPU cpu = await _db.CPUs.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);

            return View(cpu);
        }

        public async Task<IActionResult> FramePage(int? id)
        {
            ComputerFrame frame = await _db.ComputerFrames.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);

            return View(frame);
        }

        public async Task<IActionResult> GPUPage(int? id)
        {
            GPU gpu = await _db.GPUs.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);

            return View(gpu);
        }

        public async Task<IActionResult> HDDPage(int? id)
        {
            HDD hhd = await _db.HDDs.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);

            return View(hhd);
        }

        public async Task<IActionResult> MotherboardPage(int? id)
        {
            Motherboard motherboard = await _db.Motherboards.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);

            return View(motherboard);
        }

        public async Task<IActionResult> PhonePage(int? id)
        {
            Phone phone = await _db.Phones.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);

            return View(phone);
        }

        public async Task<IActionResult> PowerSupplyPage(int? id)
        {
            PowerSupply supply = await _db.PowerSupplies.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);

            return View(supply);
        }

        public async Task<IActionResult> RAMPage(int? id)
        {
            RAM ram = await _db.RAMs.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);

            return View(ram);
        }

        public async Task<IActionResult> SSDPage(int? id)
        {
            SSD ssd = await _db.SSDs.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);

            return View(ssd);
        }

        public async Task<IActionResult> ComputerPage(int? id)
        {
            Computer computer = await _db.Computers.Include(m => m.Manufacturer)
                                                   .Include(c=>c.CPU)
                                                   .Include(c => c.GPU)
                                                   .Include(c => c.HDD)
                                                   .Include(c => c.Motherboard)
                                                   .Include(c => c.PowerSupply)
                                                   .Include(c => c.RAM)
                                                   .Include(c => c.SSD)
                                                   .FirstOrDefaultAsync(p => p.Id == id);

            return View(computer);
        }
    }
}