using PerfectSite.Data.Products;

namespace PerfectSite.Data.Manufacturers.PowerSupplyManufacturers
{
    public class Thermaltake : PowerSupplyManufacturer
    {
        public Thermaltake()
        {
            Products = new List<PowerSupply>();
        }
    }
}