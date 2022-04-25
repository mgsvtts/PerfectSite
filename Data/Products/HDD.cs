using WebApplication1.Data.Manufacturers.HDDManufacturers;
using WebApplication1.Data.VirtualClasses;

namespace WebApplication1.Data.Products
{
    public class HDD : VirtualProduct
    {
        public HDDManufacturer Manufacturer { get; set; }
        public double FormFactor { get; set; }
        public string Interface { get; set; }
        public double Bandwidth { get; set; }
    }
}