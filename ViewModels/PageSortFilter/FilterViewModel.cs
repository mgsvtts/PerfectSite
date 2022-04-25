using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.ViewModels.PageSortFilter
{
    public class FilterViewModel
    {
        public SelectList Manufacturers { get; set; }
        public int? SelectedManufacturer { get; set; }
        public string SelectedName { get; set; }
    }
}