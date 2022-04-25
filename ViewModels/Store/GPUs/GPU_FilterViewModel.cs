using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data.Manufacturers.GPUManufacturers;
using WebApplication1.ViewModels.PageSortFilter;

namespace WebApplication1.ViewModels.Store.GPUs
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