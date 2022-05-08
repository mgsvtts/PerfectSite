using Microsoft.AspNetCore.Mvc;
using PerfectSite.Data.Products;

namespace PerfectSite.Areas.Store.ViewModels.ProductPage
{
    public class GPUPageViewModel
    {
        public GPU GPU { get; set; }
        public List<ComputerFrame> SuitableFrames { get; set; }
    }
}