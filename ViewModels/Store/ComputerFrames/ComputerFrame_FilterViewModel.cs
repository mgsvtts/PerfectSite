using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data.ManufacturersComputerFrameManufacturers;
using WebApplication1.ViewModels.PageSortFilter;

namespace WebApplication1.ViewModels.Store.ComputerFrames
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