using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data.Manufacturers.RAMManufacturer;
using WebApplication1.ViewModels.PageSortFilter;

namespace WebApplication1.ViewModels.Store.RAMs
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