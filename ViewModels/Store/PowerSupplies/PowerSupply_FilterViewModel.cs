using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data.Manufacturers.PowerSupplyManufacturers;
using WebApplication1.ViewModels.PageSortFilter;

namespace WebApplication1.ViewModels.Store.PowerSupplies
{
    public class PowerSupply_FilterViewModel : FilterViewModel
    {
        public PowerSupply_FilterViewModel(List<PowerSupplyManufacturer> manufacturers, int? manufacturer, string name)
        {
            manufacturers.Insert(0, new PowerSupplyManufacturer { Name = "Все", Id = 0 });
            Manufacturers = new SelectList(manufacturers, "Id", "Name", manufacturer);
            SelectedManufacturer = manufacturer;
            SelectedName = name;
        }
    }
}