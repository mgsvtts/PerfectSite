using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data.Manufacturers.SSDManufacturers;
using WebApplication1.ViewModels.PageSortFilter;

namespace WebApplication1.ViewModels.Store.SSDs
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