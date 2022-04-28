using PerfectSite.Data.Manufacturers.HDDManufacturers;
using PerfectSite.Data.VirtualClasses;

namespace PerfectSite.Data.Products
{
    public class HDD : VirtualProduct
    {
        public HDDManufacturer Manufacturer { get; set; }
        public double FormFactor { get; set; }
        public string Interface { get; set; }
        public double Bandwidth { get; set; }
    }
}