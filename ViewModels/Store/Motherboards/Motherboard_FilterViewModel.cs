using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data.Manufacturers.MotherboardManufacturers;
using WebApplication1.ViewModels.PageSortFilter;

namespace WebApplication1.ViewModels.Store.Motherboards
{
    public class Motherboard_FilterViewModel : FilterViewModel
    {
        public Motherboard_FilterViewModel(List<MotherboardManufacturer> manufacturers, int? manufacturer, string name)
        {
            manufacturers.Insert(0, new MotherboardManufacturer { Name = "Все", Id = 0 });
            Manufacturers = new SelectList(manufacturers, "Id", "Name", manufacturer);
            SelectedManufacturer = manufacturer;
            SelectedName = name;
        }
    }
}