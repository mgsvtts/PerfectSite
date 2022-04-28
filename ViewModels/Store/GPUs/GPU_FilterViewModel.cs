using Microsoft.AspNetCore.Mvc.Rendering;
using PerfectSite.Data.Manufacturers.GPUManufacturers;
using PerfectSite.ViewModels.PageSortFilter;

namespace PerfectSite.ViewModels.Store.GPUs
{
    public class GPU_FilterViewModel : FilterViewModel
    {
        public GPU_FilterViewModel(List<GPUManufacturer> manufacturers, int? manufacturer, string name)
        {
            manufacturers.Insert(0, new GPUManufacturer { Name = "Все", Id = 0 });
            Manufacturers = new SelectList(manufacturers, "Id", "Name", manufacturer);
            SelectedManufacturer = manufacturer;
            SelectedName = name;
        }
    }
}