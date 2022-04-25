using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data.ManufacturersComputerManufacturers;
using WebApplication1.ViewModels.PageSortFilter;

namespace WebApplication1.ViewModels.Store.Computers
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