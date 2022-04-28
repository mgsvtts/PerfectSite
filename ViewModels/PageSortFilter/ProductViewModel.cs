using PerfectSite.Data.VirtualClasses;

namespace PerfectSite.ViewModels.PageSortFilter
{
    public class ProductViewModel<T> where T : VirtualProduct
    {
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public SortingViewModel SortingViewModel { get; set; }
        public IEnumerable<T> Products { get; set; }
    }
}