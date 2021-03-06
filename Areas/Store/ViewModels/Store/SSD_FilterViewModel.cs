using Microsoft.AspNetCore.Mvc.Rendering;
using PerfectSite.Data.Manufacturers.SSDManufacturers;
using PerfectSite.Areas.Store.ViewModels.PageSortFilter;
using Microsoft.AspNetCore.Mvc;

namespace PerfectSite.Areas.Store.ViewModels.Store.SSDs
{
    public class SSD_FilterViewModel : FilterViewModel
    {
        public SSD_FilterViewModel(List<SSDManufacturer> manufacturers, int? manufacturer, string name)
        {
            manufacturers.Insert(0, new SSDManufacturer { Name = "Все", Id = 0 });
            Manufacturers = new SelectList(manufacturers, "Id", "Name", manufacturer);
            SelectedManufacturer = manufacturer;
            SelectedName = name;
        }
    }
}