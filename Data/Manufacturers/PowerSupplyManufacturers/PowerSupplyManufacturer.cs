using PerfectSite.Data.Products;
using PerfectSite.Data.VirtualClasses;

namespace PerfectSite.Data.Manufacturers.PowerSupplyManufacturers
{
    public class PowerSupplyManufacturer : VirtualManufacturer
    {
        public List<PowerSupply> Products { get; set; }
    }
}