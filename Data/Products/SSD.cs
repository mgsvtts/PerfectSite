using WebApplication1.Data.Manufacturers.SSDManufacturers;
using WebApplication1.Data.VirtualClasses;

namespace WebApplication1.Data.Products
{
    public class SSD : VirtualProduct
    {
        public SSDManufacturer Manufacturer { get; set; }
        public double FormFactor { get; set; }
        public string Interface { get; set; }
        public double Bandwidth { get; set; }
    }
}