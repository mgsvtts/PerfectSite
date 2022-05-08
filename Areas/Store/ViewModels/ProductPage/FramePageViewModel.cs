using Microsoft.AspNetCore.Mvc;
using PerfectSite.Data.Products;

namespace PerfectSite.Areas.Store.ViewModels.ProductPage
{
    public class FramePageViewModel
    {
        public ComputerFrame Frame { get; set; }
        public List<GPU> SuitableGPUs { get; set; }
    }
}