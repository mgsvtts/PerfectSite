using Microsoft.AspNetCore.Mvc.Rendering;
using PerfectSite.Data.Manufacturers.PhoneManufacturers;
using PerfectSite.Areas.Store.ViewModels.PageSortFilter;
using Microsoft.AspNetCore.Mvc;

namespace PerfectSite.Areas.Store.ViewModels.Store.Phones
{
    public class Phone_FilterViewModel : FilterViewModel
    {
        public Phone_FilterViewModel(List<PhoneManufacturer> manufacturers, int? manufacturer, string name)
        {
            manufacturers.Insert(0, new PhoneManufacturer { Name = "Все", Id = 0 });
            Manufacturers = new SelectList(manufacturers, "Id", "Name", manufacturer);
            SelectedManufacturer = manufacturer;
            SelectedName = name;
        }
    }
}