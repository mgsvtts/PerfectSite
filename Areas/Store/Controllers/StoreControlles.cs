using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectSite.Data.Products;
using PerfectSite.Areas.Store.ViewModels.Store.CPUs;
using PerfectSite.Areas.Store.ViewModels.Store.GPUs;
using PerfectSite.Areas.Store.ViewModels.Store.HDDs;
using PerfectSite.Areas.Store.ViewModels.Store.Motherboards;
using PerfectSite.Areas.Store.ViewModels.Store.Phones;
using PerfectSite.Areas.Store.ViewModels.Store.PowerSupplies;
using PerfectSite.Areas.Store.ViewModels.Store.RAMs;
using PerfectSite.Areas.Store.ViewModels.Store.SSDs;
using PerfectSite.Areas.Store.ViewModels.Store;
using PerfectSite.Areas.Store.ViewModels.PageSortFilter;

namespace PerfectSite.Areas.Store.Controllers
{
    public class StoreController : Controller
    {
        private readonly ApplicationContext _db;

        public StoreController(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> CPUs(int? manufacturer, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<CPU> cpus = _db.CPUs.Include(p => p.Manufacturer);

            ControllerActions<CPU> actions = new ControllerActions<CPU>(cpus);

            cpus = actions.AddFilter(manufacturer, name);

            cpus = actions.AddSort(sortOrder);

            (int count, page, List<CPU> items) = actions.AddPagination(page).Result;

            ProductViewModel<CPU> viewModel = new ProductViewModel<CPU>
            {
                PageViewModel = new PageViewModel(count, page),
                SortingViewModel = new SortingViewModel(sortOrder),
                FilterViewModel = new CPU_FilterViewModel(await _db.CPUManufacturers.ToListAsync(), manufacturer, name),
                Products = items
            };

            return View("~/Areas/Store/Views/Store/CPUs.cshtml", viewModel);
        }

        public async Task<IActionResult> Frames(int? manufacturer, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<ComputerFrame> frames = _db.ComputerFrames.Include(p => p.Manufacturer);

            ControllerActions<ComputerFrame> actions = new ControllerActions<ComputerFrame>(frames);

            frames = actions.AddFilter(manufacturer, name);

            frames = actions.AddSort(sortOrder);

            (int count, page, List<ComputerFrame> items) = actions.AddPagination(page).Result;

            ProductViewModel<ComputerFrame> viewModel = new ProductViewModel<ComputerFrame>
            {
                PageViewModel = new PageViewModel(count, page),
                SortingViewModel = new SortingViewModel(sortOrder),
                FilterViewModel = new ComputerFrame_FilterViewModel(await _db.ComputerFrameManufacturers.ToListAsync(), manufacturer, name),
                Products = items
            };

            return View("~/Areas/Store/Views/Store/Frames.cshtml", viewModel);
        }

        public async Task<IActionResult> Phones(int? manufacturer, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<Phone> phones = _db.Phones.Include(p => p.Manufacturer);

            ControllerActions<Phone> actions = new ControllerActions<Phone>(phones);

            phones = actions.AddFilter(manufacturer, name);

            phones = actions.AddSort(sortOrder);

            (int count, page, List<Phone> items) = actions.AddPagination(page).Result;

            ProductViewModel<Phone> viewModel = new ProductViewModel<Phone>
            {
                PageViewModel = new PageViewModel(count, page),
                SortingViewModel = new SortingViewModel(sortOrder),
                FilterViewModel = new Phone_FilterViewModel(await _db.PhoneManufacturers.ToListAsync(), manufacturer, name),
                Products = items
            };

            return View("~/Areas/Store/Views/Store/Phones.cshtml", viewModel);
        }

        public async Task<IActionResult> GPUs(int? manufacturer, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<GPU> gpus = _db.GPUs.Include(p => p.Manufacturer);

            ControllerActions<GPU> actions = new ControllerActions<GPU>(gpus);

            gpus = actions.AddFilter(manufacturer, name);

            gpus = actions.AddSort(sortOrder);

            (int count, page, List<GPU> items) = actions.AddPagination(page).Result;

            ProductViewModel<GPU> viewModel = new ProductViewModel<GPU>
            {
                PageViewModel = new PageViewModel(count, page),
                SortingViewModel = new SortingViewModel(sortOrder),
                FilterViewModel = new GPU_FilterViewModel(await _db.GPUManufacturers.ToListAsync(), manufacturer, name),
                Products = items
            };

            return View("~/Areas/Store/Views/Store/GPUs.cshtml", viewModel);
        }

        public async Task<IActionResult> HDDs(int? manufacturer, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<HDD> hdds = _db.HDDs.Include(p => p.Manufacturer);

            ControllerActions<HDD> actions = new ControllerActions<HDD>(hdds);

            hdds = actions.AddFilter(manufacturer, name);

            hdds = actions.AddSort(sortOrder);

            (int count, page, List<HDD> items) = actions.AddPagination(page).Result;

            ProductViewModel<HDD> viewModel = new ProductViewModel<HDD>
            {
                PageViewModel = new PageViewModel(count, page),
                SortingViewModel = new SortingViewModel(sortOrder),
                FilterViewModel = new HDD_FilterViewModel(await _db.HDDManufacturers.ToListAsync(), manufacturer, name),
                Products = items
            };

            return View("~/Areas/Store/Views/Store/HDDs.cshtml", viewModel);
        }

        public async Task<IActionResult> Motherboards(int? manufacturer, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<Motherboard> motherboards = _db.Motherboards.Include(p => p.Manufacturer);

            ControllerActions<Motherboard> actions = new ControllerActions<Motherboard>(motherboards);

            motherboards = actions.AddFilter(manufacturer, name);

            motherboards = actions.AddSort(sortOrder);

            (int count, page, List<Motherboard> items) = actions.AddPagination(page).Result;

            ProductViewModel<Motherboard> viewModel = new ProductViewModel<Motherboard>
            {
                PageViewModel = new PageViewModel(count, page),
                SortingViewModel = new SortingViewModel(sortOrder),
                FilterViewModel = new Motherboard_FilterViewModel(await _db.MotherboardManufacturers.ToListAsync(), manufacturer, name),
                Products = items
            };

            return View("~/Areas/Store/Views/Store/Motherboards.cshtml", viewModel);
        }

        public async Task<IActionResult> PowerSupplies(int? manufacturer, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<PowerSupply> powerSupplies = _db.PowerSupplies.Include(p => p.Manufacturer);

            ControllerActions<PowerSupply> actions = new ControllerActions<PowerSupply>(powerSupplies);

            powerSupplies = actions.AddFilter(manufacturer, name);

            powerSupplies = actions.AddSort(sortOrder);

            (int count, page, List<PowerSupply> items) = actions.AddPagination(page).Result;

            ProductViewModel<PowerSupply> viewModel = new ProductViewModel<PowerSupply>
            {
                PageViewModel = new PageViewModel(count, page),
                SortingViewModel = new SortingViewModel(sortOrder),
                FilterViewModel = new PowerSupply_FilterViewModel(await _db.PowerSupplyManufacturers.ToListAsync(), manufacturer, name),
                Products = items
            };

            return View("~/Areas/Store/Views/Store/PowerSupplies.cshtml", viewModel);
        }

        public async Task<IActionResult> RAMs(int? manufacturer, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<RAM> rams = _db.RAMs.Include(p => p.Manufacturer);

            ControllerActions<RAM> actions = new ControllerActions<RAM>(rams);

            rams = actions.AddFilter(manufacturer, name);

            rams = actions.AddSort(sortOrder);

            (int count, page, List<RAM> items) = actions.AddPagination(page).Result;

            ProductViewModel<RAM> viewModel = new ProductViewModel<RAM>
            {
                PageViewModel = new PageViewModel(count, page),
                SortingViewModel = new SortingViewModel(sortOrder),
                FilterViewModel = new RAM_FilterViewModel(await _db.RAMManufacturers.ToListAsync(), manufacturer, name),
                Products = items
            };

            return View("~/Areas/Store/Views/Store/RAMs.cshtml", viewModel);
        }

        public async Task<IActionResult> SSDs(int? manufacturer, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<SSD> rams = _db.SSDs.Include(p => p.Manufacturer);

            ControllerActions<SSD> actions = new ControllerActions<SSD>(rams);

            rams = actions.AddFilter(manufacturer, name);

            rams = actions.AddSort(sortOrder);

            (int count, page, List<SSD> items) = actions.AddPagination(page).Result;

            ProductViewModel<SSD> viewModel = new ProductViewModel<SSD>
            {
                PageViewModel = new PageViewModel(count, page),
                SortingViewModel = new SortingViewModel(sortOrder),
                FilterViewModel = new SSD_FilterViewModel(await _db.SSDManufacturers.ToListAsync(), manufacturer, name),
                Products = items
            };

            return View("~/Areas/Store/Views/Store/SSDs.cshtml", viewModel);
        }

        public async Task<IActionResult> Computers(int? manufacturer, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<Computer> computers = _db.Computers.Include(p => p.Manufacturer);

            ControllerActions<Computer> actions = new ControllerActions<Computer>(computers);

            computers = actions.AddFilter(manufacturer, name);

            computers = actions.AddSort(sortOrder);

            (int count, page, List<Computer> items) = actions.AddPagination(page).Result;

            ProductViewModel<Computer> viewModel = new ProductViewModel<Computer>
            {
                PageViewModel = new PageViewModel(count, page),
                SortingViewModel = new SortingViewModel(sortOrder),
                FilterViewModel = new Computer_FilterViewModel(await _db.ComputerManufacturers.ToListAsync(), manufacturer, name),
                Products = items
            };

            return View("~/Areas/Store/Views/Store/Computers.cshtml", viewModel);
        }
    }
}