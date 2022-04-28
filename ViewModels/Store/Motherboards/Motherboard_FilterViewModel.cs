using Microsoft.AspNetCore.Mvc.Rendering;
using PerfectSite.Data.Manufacturers.MotherboardManufacturers;
using PerfectSite.ViewModels.PageSortFilter;

namespace PerfectSite.ViewModels.Store.Motherboards
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