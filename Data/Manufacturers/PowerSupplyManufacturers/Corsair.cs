using PerfectSite.Data.Products;

namespace PerfectSite.Data.Manufacturers.PowerSupplyManufacturers
{
    public class Corsair : PowerSupplyManufacturer
    {
        public Corsair()
        {
            Products = new List<PowerSupply>();
        }
    }
}