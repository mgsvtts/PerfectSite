using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PerfectSite.Areas.Store.ViewModels.PageSortFilter;
using PerfectSite.Data.ManufacturersComputerManufacturers;

namespace PerfectSite.Areas.Store.ViewModels.Store
{
    public class Computer_FilterViewModel : FilterViewModel
    {
        public Computer_FilterViewModel(List<ComputerManufacturer> manufacturers, int? manufacturer, string name)
        {
            manufacturers.Insert(0, new ComputerManufacturer { Name = "Все", Id = 0 });
            Manufacturers = new SelectList(manufacturers, "Id", "Name", manufacturer);
            SelectedManufacturer = manufacturer;
            SelectedName = name;
        }
    }
}