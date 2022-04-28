using Microsoft.AspNetCore.Mvc.Rendering;
using PerfectSite.Data.Manufacturers.RAMManufacturer;
using PerfectSite.ViewModels.PageSortFilter;

namespace PerfectSite.ViewModels.Store.RAMs
{
    public class RAM_FilterViewModel : FilterViewModel
    {
        public RAM_FilterViewModel(List<RAMManufacturer> manufacturers, int? manufacturer, string name)
        {
            manufacturers.Insert(0, new RAMManufacturer { Name = "Все", Id = 0 });
            Manufacturers = new SelectList(manufacturers, "Id", "Name", manufacturer);
            SelectedManufacturer = manufacturer;
            SelectedName = name;
        }
    }
}