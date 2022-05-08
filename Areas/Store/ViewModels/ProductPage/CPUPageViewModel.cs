using Microsoft.AspNetCore.Mvc;
using PerfectSite.Data.Products;

namespace PerfectSite.Areas.Store.ViewModels.ProductPage
{
    public class CPUPageViewModel
    {
        public CPU CPU { get; set; }
        public List<Motherboard>? SuitableMotherboards { get; set; }
    }
}