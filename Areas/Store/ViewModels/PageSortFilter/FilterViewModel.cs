using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PerfectSite.Areas.Store.ViewModels.PageSortFilter
{
    public class FilterViewModel
    {
        public SelectList Manufacturers { get; set; }
        public int? SelectedManufacturer { get; set; }
        public string SelectedName { get; set; }
    }
}