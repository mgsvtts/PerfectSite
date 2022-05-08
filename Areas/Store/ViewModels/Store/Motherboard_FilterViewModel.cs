using Microsoft.AspNetCore.Mvc.Rendering;
using PerfectSite.Data.Manufacturers.MotherboardManufacturers;
using PerfectSite.Areas.Store.ViewModels.PageSortFilter;
using Microsoft.AspNetCore.Mvc;

namespace PerfectSite.Areas.Store.ViewModels.Store.Motherboards
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