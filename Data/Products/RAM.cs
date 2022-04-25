using WebApplication1.Data.Manufacturers.RAMManufacturer;
using WebApplication1.Data.VirtualClasses;

namespace WebApplication1.Data.Products
{
    public class RAM : VirtualProduct
    {
        public RAMManufacturer Manufacturer { get; set; }
        public double Speed { get; set; }
        public int MemorySize { get; set; }
    }
}