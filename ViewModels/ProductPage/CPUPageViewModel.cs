using PerfectSite.Data.Products;

namespace PerfectSite.ViewModels.ProductPage
{
    public class CPUPageViewModel
    {
        public CPU CPU { get; set; }
        public List<Motherboard>? SuitableMotherboards { get; set; }
    }
}
