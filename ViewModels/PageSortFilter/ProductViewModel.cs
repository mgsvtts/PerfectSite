using WebApplication1.Data.VirtualClasses;

namespace WebApplication1.ViewModels.PageSortFilter
{
    public class ProductViewModel<T> where T : VirtualProduct
    {
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public SortingViewModel SortingViewModel { get; set; }
        public IEnumerable<T> Products { get; set; }
    }
}