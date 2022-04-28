using PerfectSite.Data.Manufacturers.GPUManufacturers;
using PerfectSite.Data.VirtualClasses;

namespace PerfectSite.Data.Products
{
    public class GPU : VirtualProduct
    {
        public GPUManufacturer Manufacturer { get; set; }
        public int MemorySize { get; set; }
        public string MemoryType { get; set; }
        public double MemoryFrequency { get; set; }
        public double GPUFrequency { get; set; }
        public double Size { get; set; }
    }
}