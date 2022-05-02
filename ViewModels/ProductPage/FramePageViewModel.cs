using PerfectSite.Data.Products;

namespace PerfectSite.ViewModels.ProductPage
{
    public class FramePageViewModel
    {
        public ComputerFrame Frame { get; set; }
        public List<GPU> SuitableGPUs { get; set; }
    }
}
