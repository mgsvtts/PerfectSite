using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data.Manufacturers.CPUManufacturers;
using WebApplication1.ViewModels.PageSortFilter;

namespace WebApplication1.ViewModels.Store.CPUs
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