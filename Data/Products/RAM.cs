using PerfectSite.Data.Manufacturers.RAMManufacturer;
using PerfectSite.Data.VirtualClasses;

namespace PerfectSite.Data.Products
{
    public class RAM : VirtualProduct
    {
        public RAMManufacturer Manufacturer { get; set; }
        public double Speed { get; set; }
        public int MemorySize { get; set; }
    }
}