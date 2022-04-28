using PerfectSite.Data.Manufacturers.PowerSupplyManufacturers;
using PerfectSite.Data.VirtualClasses;

namespace PerfectSite.Data.Products
{
    public class PowerSupply : VirtualProduct
    {
        public PowerSupplyManufacturer Manufacturer { get; set; }
        public int Power { get; set; }
        public string Certificate { get; set; }
    }
}