using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data.Manufacturers.HDDManufacturers;
using WebApplication1.ViewModels.PageSortFilter;

namespace WebApplication1.ViewModels.Store.HDDs
{
    public class HDD_FilterViewModel : FilterViewModel
    {
        public HDD_FilterViewModel(List<HDDManufacturer> manufacturers, int? manufacturer, string name)
        {
            manufacturers.Insert(0, new HDDManufacturer { Name = "Все", Id = 0 });
            Manufacturers = new SelectList(manufacturers, "Id", "Name", manufacturer);
            SelectedManufacturer = manufacturer;
            SelectedName = name;
        }
    }
}