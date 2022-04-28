using Microsoft.AspNetCore.Mvc.Rendering;
using PerfectSite.Data.ManufacturersComputerFrameManufacturers;
using PerfectSite.ViewModels.PageSortFilter;

namespace PerfectSite.ViewModels.Store.ComputerFrames
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