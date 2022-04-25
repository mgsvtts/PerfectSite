using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data.Manufacturers.PhoneManufacturers;
using WebApplication1.ViewModels.PageSortFilter;

namespace WebApplication1.ViewModels.Store.Phones
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