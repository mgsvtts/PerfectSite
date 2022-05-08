using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PerfectSite.Areas.Store.ViewModels.PageSortFilter;
using PerfectSite.Data.ManufacturersComputerFrameManufacturers;

namespace PerfectSite.Areas.Store.ViewModels.Store
{
    public class ComputerFrame_FilterViewModel : FilterViewModel
    {
        public ComputerFrame_FilterViewModel(List<ComputerFrameManufacturer> manufacturers, int? manufacturer, string name)
        {
            manufacturers.Insert(0, new ComputerFrameManufacturer { Name = "Все", Id = 0 });
            Manufacturers = new SelectList(manufacturers, "Id", "Name", manufacturer);
            SelectedManufacturer = manufacturer;
            SelectedName = name;
        }
    }
}