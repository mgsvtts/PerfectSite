using Microsoft.AspNetCore.Mvc.Rendering;
using PerfectSite.Data.Manufacturers.CPUManufacturers;
using PerfectSite.ViewModels.PageSortFilter;

namespace PerfectSite.ViewModels.Store.CPUs
{
    public class CPU_FilterViewModel : FilterViewModel
    {
        public CPU_FilterViewModel(List<CPUManufacturer> manufacturers, int? manufacturer, string name)
        {
            manufacturers.Insert(0, new CPUManufacturer { Name = "Все", Id = 0 });
            Manufacturers = new SelectList(manufacturers, "Id", "Name", manufacturer);
            SelectedManufacturer = manufacturer;
            SelectedName = name;
        }
    }
}