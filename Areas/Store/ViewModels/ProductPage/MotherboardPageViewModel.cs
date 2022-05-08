using Microsoft.AspNetCore.Mvc;
using PerfectSite.Data.Products;

namespace PerfectSite.Areas.Store.ViewModels.ProductPage
{
    public class MotherboardPageViewModel
    {
        public Motherboard Motherboard { get; set; }
        public List<CPU>? SuitableCPUs { get; set; }
    }
}