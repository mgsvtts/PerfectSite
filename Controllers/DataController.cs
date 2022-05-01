using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectSite.CustomUtilities;
using PerfectSite.Data.ManufacturersComputerManufacturers;
using PerfectSite.Data.Products;
using PerfectSite.ViewModels.Data;

namespace PerfectSite.Controllers
{
    [Authorize(Roles = "God of the Site")]
    public class DataController : Controller
    {
        private readonly ApplicationContext _db;

        public DataController(ApplicationContext db)
        {
            _db = db;
        }

        public IActionResult Main()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Computer_Create()
        {
            return View("~/Views/Data/Computer/Computer_Create.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Computer_Create(Computer_ViewModel model)
        {
            if (ModelState.IsValid)
            {
                CPU cpu = await _db.CPUs.FirstOrDefaultAsync(u=>u.ModelName == model.CPUName);
                RAM ram = await _db.RAMs.FirstOrDefaultAsync(u => u.ModelName == model.RAMName);
                Motherboard motherboard = await _db.Motherboards.FirstOrDefaultAsync(u => u.ModelName == model.MotherboardName);
                PowerSupply powerSupply= await _db.PowerSupplies.FirstOrDefaultAsync(u => u.ModelName == model.PowerSupplyName);
                ComputerFrame frame = await _db.ComputerFrames.FirstOrDefaultAsync(u => u.ModelName == model.FrameName);
                GPU? gpu = await _db.GPUs.FirstOrDefaultAsync(u => u.ModelName == model.GPUName);
                HDD? hdd = await _db.HDDs.FirstOrDefaultAsync(u => u.ModelName == model.HDDName);
                SSD? ssd = await _db.SSDs.FirstOrDefaultAsync(u => u.ModelName == model.SSDName);
                ComputerManufacturer? manufacturer = await _db.ComputerManufacturers.FirstOrDefaultAsync(u => u.Name == model.ManufacturerName);

                ComputerValidation.Validate(cpu, gpu, ram, motherboard, powerSupply, frame, ssd, hdd, this, model);

                if(ModelState.ErrorCount > 0)
                    return View("~/Views/Data/Computer/Computer_Create.cshtml", model);
                
                
                Computer computer = new Computer
                {
                    CPU = cpu,
                    RAM = ram,
                    Motherboard = motherboard,
                    PowerSupply = powerSupply,
                    Frame = frame,
                    GPU = gpu,
                    HDD = hdd,
                    SSD = ssd,
                    Manufacturer = manufacturer,
                    Amount = model.Amount,
                    BoughtTimes = model.BoughtTimes,
                    Description = model.Description,
                    ModelName = model.ModelName,
                    Price = model.Price
                    
                };

                _db.Computers.Add(computer);
                await _db.SaveChangesAsync();
                return RedirectToAction("Computers", "Store");
            }

            return View("~/Views/Data/Computer/Computer_Create.cshtml", model);
        }

        public async Task<IActionResult> Computer_Details(int? id)
        {
            if (id != null)
            {
                Computer computer = await _db.Computers
                                          .Include(m => m.Manufacturer)
                                          .Include(m => m.CPU)
                                          .Include(m => m.GPU)
                                          .Include(m => m.SSD)
                                          .Include(m => m.HDD)
                                          .Include(m => m.RAM)
                                          .Include(m => m.Motherboard)
                                          .Include(m => m.PowerSupply)
                                          .Include(m => m.Frame)
                                          .FirstOrDefaultAsync(p => p.Id == id);
                if (computer != null)
                {
                    return View("~/Views/Data/Computer/Computer_Details.cshtml", computer);
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> Computer_Edit(int? id)
        {
            if (id != null)
            {
                Computer computer = await _db.Computers
                                          .Include(m => m.Manufacturer)
                                          .Include(m => m.CPU)
                                          .Include(m => m.GPU)
                                          .Include(m => m.SSD)
                                          .Include(m => m.HDD)
                                          .Include(m => m.RAM)
                                          .Include(m => m.Motherboard)
                                          .Include(m => m.PowerSupply)
                                          .Include(m => m.Frame)
                                          .FirstOrDefaultAsync(p => p.Id == id);
               
                if (computer != null)
                {
                    Computer_ViewModel model = new Computer_ViewModel
                    {
                        ModelName = computer.ModelName,
                        ManufacturerName = computer.Manufacturer?.Name,
                        CPUName = computer.CPU?.ModelName,
                        GPUName = computer.GPU?.ModelName,
                        SSDName = computer.SSD?.ModelName,
                        HDDName = computer.HDD?.ModelName,
                        RAMName = computer.RAM?.ModelName,
                        MotherboardName = computer.Motherboard?.ModelName,
                        PowerSupplyName = computer.PowerSupply?.ModelName,
                        FrameName = computer.Frame?.ModelName,
                        Price = computer.Price,
                        Amount = computer.Amount,
                        BoughtTimes  = computer.BoughtTimes,
                        Description = computer.Description,
                        Manufacturer = computer.Manufacturer,
                        Id = computer.Id 
                        
                    };
                    
                    return View("~/Views/Data/Computer/Computer_Edit.cshtml", model);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Computer_Edit(Computer_ViewModel model)
        {
            if (ModelState.IsValid)
            {
                Computer computer = _db.Computers.FirstOrDefault(p => p.Id == model.Id);
                if (computer != null)
                {
                    ComputerManufacturer? manufacturer = await _db.ComputerManufacturers.FirstOrDefaultAsync(m => m.Name == model.ManufacturerName);
                    CPU cpu = await _db.CPUs.FirstOrDefaultAsync(m => m.ModelName == model.CPUName);
                    GPU? gpu = await _db.GPUs.FirstOrDefaultAsync(m => m.ModelName == model.GPUName); 
                    SSD? ssd = await _db.SSDs.FirstOrDefaultAsync(m => m.ModelName == model.SSDName);
                    HDD? hdd = await _db.HDDs.FirstOrDefaultAsync(m => m.ModelName == model.HDDName);
                    RAM ram = await _db.RAMs.FirstOrDefaultAsync(m => m.ModelName == model.RAMName);
                    Motherboard motherboard = await _db.Motherboards.FirstOrDefaultAsync(m => m.ModelName == model.MotherboardName);
                    PowerSupply powerSupply = await _db.PowerSupplies.FirstOrDefaultAsync(m => m.ModelName == model.PowerSupplyName);
                    ComputerFrame frame = await _db.ComputerFrames.FirstOrDefaultAsync(m => m.ModelName == model.FrameName);


                    ComputerValidation.Validate(cpu, gpu, ram, motherboard, powerSupply, frame, ssd, hdd, this, model);

                    if (ModelState.ErrorCount > 0)
                        return View("~/Views/Data/Computer/Computer_Edti.cshtml", model);


                    Computer newcomputer = new Computer
                    {
                        Manufacturer = manufacturer,
                        CPU = cpu,
                        GPU = gpu,
                        SSD = ssd,
                        HDD = hdd,
                        RAM = ram,
                        Motherboard = motherboard,
                        PowerSupply = powerSupply,
                        Frame = frame,
                        BoughtTimes = model.BoughtTimes,
                        Description = model.Description,
                        ModelName = model.ModelName,
                        Price = model.Price,
                        Amount = model.Amount,
                        Id = computer.Id,
                        

                    };

                    _db.Computers.Remove(computer);
                    _db.Computers.Add(newcomputer);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Computers", "Store");
                    

                }
            }
            
            return View("~/Views/Data/Computer/Computer_Edit.cshtml", model);
        }

        [HttpGet]
        [ActionName("Computer_Delete")]
        public async Task<IActionResult> Computer_GetDelete(int? id)
        {
            if (id != null)
            {
                Computer computer = await _db.Computers.FirstOrDefaultAsync(p => p.Id == id);

                if (computer != null)
                {
                    return View("~/Views/Data/Computer/Computer_Delete.cshtml", computer);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Computer_Delete(int? id)
        {
            if (id != null)
            {
                Computer computer = new Computer { Id = id.Value };
                _db.Entry(computer).State = EntityState.Deleted;
                await _db.SaveChangesAsync();

                return RedirectToAction("Computers", "Store");
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult CPU_Create()
        {
            return View("~/Views/Data/CPU/CPU_Create.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> CPU_Create(CPU product)
        {
            if (ModelState.IsValid)
            {
                _db.CPUs.Add(product);
                await _db.SaveChangesAsync();
                return RedirectToAction("CPUs", "Store");
            }

            return View("~/Views/Data/CPU/CPU_Create.cshtml", product);
        }

        public async Task<IActionResult> CPU_Details(int? id)
        {
            if (id != null)
            {
                CPU cpu = await _db.CPUs.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);
                if (cpu != null)
                {
                    return View("~/Views/Data/CPU/CPU_Details.cshtml", cpu);
                }
            }
            return NotFound();
        }

        [HttpGet]
        [ActionName("CPU_Delete")]
        public async Task<IActionResult> CPU_GetDelete(int? id)
        {
            if (id != null)
            {
                CPU cpu = await _db.CPUs.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);

                if (cpu != null)
                {
                    return View("~/Views/Data/CPU/CPU_Delete.cshtml", cpu);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CPU_Delete(int? id)
        {
            if (id != null)
            {
                CPU cpu = new CPU { Id = id.Value };
                _db.Entry(cpu).State = EntityState.Deleted;
                await _db.SaveChangesAsync();

                return RedirectToAction("CPUs", "Store");
            }
            return NotFound();
        }

        public async Task<IActionResult> CPU_Edit(int? id)
        {
            if (id != null)
            {
                CPU cpu = await _db.CPUs.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);
                if (cpu != null)
                {
                    return View("~/Views/Data/CPU/CPU_Edit.cshtml", cpu);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CPU_Edit(CPU cpu)
        {
            if (ModelState.IsValid)
            {
                _db.CPUs.Update(cpu);
                await _db.SaveChangesAsync();
                return RedirectToAction("CPUs", "Store");
            }

            return View("~/Views/Data/CPU/CPU_Edit.cshtml", cpu);
        }

        [HttpGet]
        public IActionResult Frame_Create()
        {
            return View("~/Views/Data/Frame/Frame_Create.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Frame_Create(ComputerFrame product)
        {
            if (ModelState.IsValid)
            {
                _db.ComputerFrames.Add(product);
                await _db.SaveChangesAsync();
                return RedirectToAction("Frames", "Store");
            }
            return View("~/Views/Data/Frame/Frame_Create.cshtml");
        }

        public async Task<IActionResult> Frame_Details(int? id)
        {
            if (id != null)
            {
                ComputerFrame product = await _db.ComputerFrames.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    return View("~/Views/Data/Frame/Frame_Details.cshtml", product);
                }
            }
            return NotFound();
        }

        [HttpGet]
        [ActionName("Frame_Delete")]
        public async Task<IActionResult> Frame_GetDelete(int? id)
        {
            if (id != null)
            {
                ComputerFrame product = await _db.ComputerFrames.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);

                if (product != null)
                {
                    return View("~/Views/Data/Frame/Frame_Delete.cshtml", product);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Frame_Delete(int? id)
        {
            if (id != null)
            {
                ComputerFrame product = new ComputerFrame { Id = id.Value };
                _db.Entry(product).State = EntityState.Deleted;
                await _db.SaveChangesAsync();

                return RedirectToAction("Frames", "Store");
            }
            return NotFound();
        }

        public async Task<IActionResult> Frame_Edit(int? id)
        {
            if (id != null)
            {
                ComputerFrame product = await _db.ComputerFrames.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    return View("~/Views/Data/Frame/Frame_Edit.cshtml", product);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Frame_Edit(ComputerFrame product)
        {
            if (ModelState.IsValid)
            {
                _db.ComputerFrames.Update(product);
                await _db.SaveChangesAsync();
                return RedirectToAction("Frames", "Store");
            }
            return View("~/Views/Data/Frame/Frame_Edit.cshtml", product);
        }

        [HttpGet]
        public IActionResult GPU_Create()
        {
            return View("~/Views/Data/GPU/GPU_Create.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> GPU_Create(GPU product)
        {
            if (ModelState.IsValid)
            {
                _db.GPUs.Add(product);
                await _db.SaveChangesAsync();
                return RedirectToAction("GPUs", "Store");
            }
            return View("~/Views/Data/GPU/GPU_Create.cshtml");
        }

        public async Task<IActionResult> GPU_Details(int? id)
        {
            if (id != null)
            {
                GPU product = await _db.GPUs.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    return View("~/Views/Data/GPU/GPU_Details.cshtml", product);
                }
            }
            return NotFound();
        }

        [HttpGet]
        [ActionName("GPU_Delete")]
        public async Task<IActionResult> GPU_GetDelete(int? id)
        {
            if (id != null)
            {
                GPU product = await _db.GPUs.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);

                if (product != null)
                {
                    return View("~/Views/Data/GPU/GPU_Delete.cshtml", product);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> GPU_Delete(int? id)
        {
            if (id != null)
            {
                GPU product = new GPU { Id = id.Value };
                _db.Entry(product).State = EntityState.Deleted;
                await _db.SaveChangesAsync();

                return RedirectToAction("GPUs", "Store");
            }
            return NotFound();
        }

        public async Task<IActionResult> GPU_Edit(int? id)
        {
            if (id != null)
            {
                GPU product = await _db.GPUs.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    return View("~/Views/Data/GPU/GPU_Edit.cshtml", product);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> GPU_Edit(GPU product)
        {
            if (ModelState.IsValid)
            {
                _db.GPUs.Update(product);
                await _db.SaveChangesAsync();
                return RedirectToAction("GPUs", "Store");
            }
            return View("~/Views/Data/GPU/GPU_Edit.cshtml", product);
        }

        [HttpGet]
        public IActionResult HDD_Create()
        {
            return View("~/Views/Data/HDD/HDD_Create.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> HDD_Create(HDD product)
        {
            if (ModelState.IsValid)
            {
                _db.HDDs.Add(product);
                await _db.SaveChangesAsync();
                return RedirectToAction("HDDs", "Store");
            }
            return View("~/Views/Data/HDD/HDD_Create.cshtml");
        }

        public async Task<IActionResult> HDD_Details(int? id)
        {
            if (id != null)
            {
                HDD product = await _db.HDDs.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    return View("~/Views/Data/HDD/HDD_Details.cshtml", product);
                }
            }
            return NotFound();
        }

        [HttpGet]
        [ActionName("HDD_Delete")]
        public async Task<IActionResult> HDD_GetDelete(int? id)
        {
            if (id != null)
            {
                HDD product = await _db.HDDs.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);

                if (product != null)
                {
                    return View("~/Views/Data/HDD/HDD_Delete.cshtml", product);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> HDD_Delete(int? id)
        {
            if (id != null)
            {
                HDD product = new HDD { Id = id.Value };
                _db.Entry(product).State = EntityState.Deleted;
                await _db.SaveChangesAsync();

                return RedirectToAction("HDDs", "Store");
            }
            return NotFound();
        }

        public async Task<IActionResult> HDD_Edit(int? id)
        {
            if (id != null)
            {
                HDD product = await _db.HDDs.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    return View("~/Views/Data/HDD/HDD_Edit.cshtml", product);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> HDD_Edit(HDD product)
        {
            if (ModelState.IsValid)
            {
                _db.HDDs.Update(product);
                await _db.SaveChangesAsync();
                return RedirectToAction("HDDs", "Store");
            }
            return View("~/Views/Data/HDD/HDD_Edit.cshtml", product);
        }

        [HttpGet]
        public IActionResult Motherboard_Create()
        {
            return View("~/Views/Data/Motherboard/Motherboard_Create.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Motherboard_Create(Motherboard product)
        {
            if (ModelState.IsValid)
            {
                _db.Motherboards.Add(product);
                await _db.SaveChangesAsync();
                return RedirectToAction("Motherboards", "Store");
            }
            return View("~/Views/Data/Motherboard/Motherboard_Create.cshtml");
        }

        public async Task<IActionResult> Motherboard_Details(int? id)
        {
            if (id != null)
            {
                Motherboard product = await _db.Motherboards.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    return View("~/Views/Data/Motherboard/Motherboard_Details.cshtml", product);
                }
            }
            return NotFound();
        }

        [HttpGet]
        [ActionName("Motherboard_Delete")]
        public async Task<IActionResult> Motherboard_GetDelete(int? id)
        {
            if (id != null)
            {
                Motherboard product = await _db.Motherboards.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);

                if (product != null)
                {
                    return View("~/Views/Data/Motherboard/Motherboard_Delete.cshtml", product);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Motherboard_Delete(int? id)
        {
            if (id != null)
            {
                Motherboard product = new Motherboard { Id = id.Value };
                _db.Entry(product).State = EntityState.Deleted;
                await _db.SaveChangesAsync();

                return RedirectToAction("Motherboards", "Store");
            }
            return NotFound();
        }

        public async Task<IActionResult> Motherboard_Edit(int? id)
        {
            if (id != null)
            {
                Motherboard product = await _db.Motherboards.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    return View("~/Views/Data/Motherboard/Motherboard_Edit.cshtml", product);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Motherboard_Edit(Motherboard product)
        {
            if (ModelState.IsValid)
            {
                _db.Motherboards.Update(product);
                await _db.SaveChangesAsync();
                return RedirectToAction("Motherboards", "Store");
            }
            return View("~/Views/Data/Motherboard/Motherboard_Edit.cshtml", product);
        }

        [HttpGet]
        public IActionResult Phone_Create()
        {
            return View("~/Views/Data/Phone/Phone_Create.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Phone_Create(Phone product)
        {
            if (ModelState.IsValid)
            {
                _db.Phones.Add(product);
                await _db.SaveChangesAsync();
                return RedirectToAction("Phones", "Store");
            }
            return View("~/Views/Data/Phone/Phone_Create.cshtml");
        }

        public async Task<IActionResult> Phone_Details(int? id)
        {
            if (id != null)
            {
                Phone product = await _db.Phones.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    return View("~/Views/Data/Phone/Phone_Details.cshtml", product);
                }
            }
            return NotFound();
        }

        [HttpGet]
        [ActionName("Phone_Delete")]
        public async Task<IActionResult> Phone_GetDelete(int? id)
        {
            if (id != null)
            {
                Phone product = await _db.Phones.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);

                if (product != null)
                {
                    return View("~/Views/Data/Phone/Phone_Delete.cshtml", product);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Phone_Delete(int? id)
        {
            if (id != null)
            {
                Phone product = new Phone { Id = id.Value };
                _db.Entry(product).State = EntityState.Deleted;
                await _db.SaveChangesAsync();

                return RedirectToAction("Phones", "Store");
            }
            return NotFound();
        }

        public async Task<IActionResult> Phone_Edit(int? id)
        {
            if (id != null)
            {
                Phone product = await _db.Phones.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    return View("~/Views/Data/Phone/Phone_Edit.cshtml", product);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Phone_Edit(Phone product)
        {
            if (ModelState.IsValid)
            {
                _db.Phones.Update(product);
                await _db.SaveChangesAsync();
                return RedirectToAction("Phones", "Store");
            }
            return View("~/Views/Data/Phone/Phone_Edit.cshtml", product);
        }

        [HttpGet]
        public IActionResult PowerSupply_Create()
        {
            return View("~/Views/Data/PowerSupply/PowerSupply_Create.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> PowerSupply_Create(PowerSupply product)
        {
            if (ModelState.IsValid)
            {
                _db.PowerSupplies.Add(product);
                await _db.SaveChangesAsync();
                return RedirectToAction("PowerSupplies", "Store");
            }
            return View("~/Views/Data/PowerSupply/PowerSupply_Create.cshtml");
        }

        public async Task<IActionResult> PowerSupply_Details(int? id)
        {
            if (id != null)
            {
                PowerSupply product = await _db.PowerSupplies.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    return View("~/Views/Data/PowerSupply/PowerSupply_Details.cshtml", product);
                }
            }
            return NotFound();
        }

        [HttpGet]
        [ActionName("PowerSupply_Delete")]
        public async Task<IActionResult> PowerSupply_GetDelete(int? id)
        {
            if (id != null)
            {
                PowerSupply product = await _db.PowerSupplies.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    return View("~/Views/Data/PowerSupply/PowerSupply_Delete.cshtml", product);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PowerSupply_Delete(int? id)
        {
            if (id != null)
            {
                PowerSupply product = new PowerSupply { Id = id.Value };
                _db.Entry(product).State = EntityState.Deleted;
                await _db.SaveChangesAsync();

                return RedirectToAction("PowerSupplies", "Store");
            }
            return NotFound();
        }

        public async Task<IActionResult> PowerSupply_Edit(int? id)
        {
            if (id != null)
            {
                PowerSupply product = await _db.PowerSupplies.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    return View("~/Views/Data/PowerSupply/PowerSupply_Edit.cshtml", product);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PowerSupply_Edit(PowerSupply product)
        {
            if (ModelState.IsValid)
            {
                _db.PowerSupplies.Update(product);
                await _db.SaveChangesAsync();
                return RedirectToAction("PowerSupplies", "Store");
            }
            return View("~/Views/Data/PowerSupply/PowerSupply_Edit.cshtml", product);
        }

        [HttpGet]
        public IActionResult RAM_Create()
        {
            return View("~/Views/Data/RAM/RAM_Create.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> RAM_Create(RAM product)
        {
            if (ModelState.IsValid)
            {
                _db.RAMs.Add(product);
                await _db.SaveChangesAsync();
                return RedirectToAction("RAMs", "Store");
            }
            return View("~/Views/Data/RAM/RAM_Create.cshtml");
        }

        public async Task<IActionResult> RAM_Details(int? id)
        {
            if (id != null)
            {
                RAM product = await _db.RAMs.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    return View("~/Views/Data/RAM/RAM_Details.cshtml", product);
                }
            }
            return NotFound();
        }

        [HttpGet]
        [ActionName("RAM_Delete")]
        public async Task<IActionResult> RAM_GetDelete(int? id)
        {
            if (id != null)
            {
                RAM product = await _db.RAMs.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);

                if (product != null)
                {
                    return View("~/Views/Data/RAM/RAM_Delete.cshtml", product);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> RAM_Delete(int? id)
        {
            if (id != null)
            {
                RAM product = new RAM { Id = id.Value };
                _db.Entry(product).State = EntityState.Deleted;
                await _db.SaveChangesAsync();

                return RedirectToAction("RAMs", "Store");
            }
            return NotFound();
        }

        public async Task<IActionResult> RAM_Edit(int? id)
        {
            if (id != null)
            {
                RAM product = await _db.RAMs.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    return View("~/Views/Data/RAM/RAM_Edit.cshtml", product);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> RAM_Edit(RAM product)
        {
            if (ModelState.IsValid)
            {
                _db.RAMs.Update(product);
                await _db.SaveChangesAsync();
                return RedirectToAction("RAMs", "Store");
            }
            return View("~/Views/Data/RAM/RAM_Edit.cshtml", product);
        }

        [HttpGet]
        public IActionResult SSD_Create()
        {
            return View("~/Views/Data/SSD/SSD_Create.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> SSD_Create(SSD product)
        {
            if (ModelState.IsValid)
            {
                _db.SSDs.Add(product);
                await _db.SaveChangesAsync();
                return RedirectToAction("SSDs", "Store");
            }
            return View("~/Views/Data/SSD/SSD_Create.cshtml");
        }

        public async Task<IActionResult> SSD_Details(int? id)
        {
            if (id != null)
            {
                SSD product = await _db.SSDs.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    return View("~/Views/Data/SSD/SSD_Details.cshtml", product);
                }
            }
            return NotFound();
        }

        [HttpGet]
        [ActionName("SSD_Delete")]
        public async Task<IActionResult> SSD_GetDelete(int? id)
        {
            if (id != null)
            {
                SSD product = await _db.SSDs.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);

                if (product != null)
                {
                    return View("~/Views/Data/SSD/SSD_Delete.cshtml", product);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> SSD_Delete(int? id)
        {
            if (id != null)
            {
                SSD product = new SSD { Id = id.Value };
                _db.Entry(product).State = EntityState.Deleted;
                await _db.SaveChangesAsync();

                return RedirectToAction("SSDs", "Store");
            }
            return NotFound();
        }

        public async Task<IActionResult> SSD_Edit(int? id)
        {
            if (id != null)
            {
                SSD product = await _db.SSDs.Include(m => m.Manufacturer).FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    return View("~/Views/Data/SSD/SSD_Edit.cshtml", product);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> SSD_Edit(SSD product)
        {
            if (ModelState.IsValid)
            {
                _db.SSDs.Update(product);
                await _db.SaveChangesAsync();
                return RedirectToAction("SSDs", "Store");
            }
            return View("~/Views/Data/SSD/SSD_Edit.cshtml", product);
        }


    }
}