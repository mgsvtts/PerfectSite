using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectSite.Areas.Store.ViewModels.ProductPage;
using PerfectSite.Data.Products;

namespace PerfectSite.Areas.Store.Controllers
{
    public class ProductPageController : Controller
    {
        private readonly ApplicationContext _db;

        public ProductPageController(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> CPUPage(Guid? id)
        {
            CPU cpu = await _db.CPUs.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);

            List<Motherboard> suitableMotherboards = new List<Motherboard>();

            foreach (Motherboard motherboard in _db.Motherboards)
            {
                if (motherboard.Socket == cpu.Socket)
                {
                    suitableMotherboards.Add(motherboard);
                }
            }

            return View("~/Areas/Store/Views/ProductPage/CPUPage.cshtml", new CPUPageViewModel { CPU = cpu, SuitableMotherboards = suitableMotherboards });
        }

        public async Task<IActionResult> FramePage(Guid? id)
        {
            ComputerFrame frame = await _db.ComputerFrames.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);

            List<GPU> suitableGPUs = new List<GPU>();

            foreach (GPU gpu in _db.GPUs)
            {
                if (frame.GPULength >= gpu.Size)
                {
                    suitableGPUs.Add(gpu);
                }
            }

            return View("~/Areas/Store/Views/ProductPage/FramePage.cshtml", new FramePageViewModel { Frame = frame, SuitableGPUs = suitableGPUs });
        }

        public async Task<IActionResult> GPUPage(Guid? id)
        {
            GPU gpu = await _db.GPUs.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);

            List<ComputerFrame> suitableFrames = new List<ComputerFrame>();

            foreach (ComputerFrame frame in _db.ComputerFrames)
            {
                if (gpu.Size <= frame.GPULength)
                {
                    suitableFrames.Add(frame);
                }
            }

            return View("~/Areas/Store/Views/ProductPage/GPUPage.cshtml", new GPUPageViewModel { GPU = gpu, SuitableFrames = suitableFrames });
        }

        public async Task<IActionResult> HDDPage(Guid? id)
        {
            HDD hhd = await _db.HDDs.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);

            return View("~/Areas/Store/Views/ProductPage/HDDPage.cshtml", hhd);
        }

        public async Task<IActionResult> MotherboardPage(Guid? id)
        {
            Motherboard motherboard = await _db.Motherboards.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);

            List<CPU> suitableCPUs = new List<CPU>();

            foreach (CPU cpu in _db.CPUs)
            {
                if (motherboard.Socket == cpu.Socket)
                {
                    suitableCPUs.Add(cpu);
                }
            }

            return View("~/Areas/Store/Views/ProductPage/MotherboardPage.cshtml", new MotherboardPageViewModel { Motherboard = motherboard, SuitableCPUs = suitableCPUs });
        }

        public async Task<IActionResult> PhonePage(Guid? id)
        {
            Phone phone = await _db.Phones.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);

            return View("~/Areas/Store/Views/ProductPage/PhonePage.cshtml", phone);
        }

        public async Task<IActionResult> PowerSupplyPage(Guid? id)
        {
            PowerSupply supply = await _db.PowerSupplies.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);

            return View("~/Areas/Store/Views/ProductPage/PowerSupplyPage.cshtml", supply);
        }

        public async Task<IActionResult> RAMPage(Guid? id)
        {
            RAM ram = await _db.RAMs.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);

            return View("~/Areas/Store/Views/ProductPage/RAMPage.cshtml", ram);
        }

        public async Task<IActionResult> SSDPage(Guid? id)
        {
            SSD ssd = await _db.SSDs.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);

            return View("~/Areas/Store/Views/ProductPage/SSDPage.cshtml", ssd);
        }

        public async Task<IActionResult> ComputerPage(Guid? id)
        {
            Computer computer = await _db.Computers.Include(m => m.Manufacturer)
                                                   .Include(c => c.CPU)
                                                   .Include(c => c.GPU)
                                                   .Include(c => c.HDD)
                                                   .Include(c => c.Motherboard)
                                                   .Include(c => c.PowerSupply)
                                                   .Include(c => c.RAM)
                                                   .Include(c => c.SSD)
                                                   .FirstOrDefaultAsync(p => p.Id == id);

            return View("~/Areas/Store/Views/ProductPage/ComputerPage.cshtml", computer);
        }
    }
}