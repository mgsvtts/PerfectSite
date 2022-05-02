using PerfectSite.Data.Products;

namespace PerfectSite.ViewModels.ProductPage
{
    public class MotherboardPageViewModel
    {
        public Motherboard Motherboard { get; set; }
        public List<CPU>? SuitableCPUs { get; set; }
    }
}
