using PerfectSite.Data.Manufacturers.SSDManufacturers;
using PerfectSite.Data.VirtualClasses;

namespace PerfectSite.Data.Products
{
    public class SSD : VirtualProduct
    {
        public SSDManufacturer Manufacturer { get; set; }
        public double FormFactor { get; set; }
        public string Interface { get; set; }
        public double Bandwidth { get; set; }

        public static implicit operator SSD?(ComputerFrame? v)
        {
            throw new NotImplementedException();
        }
    }
}