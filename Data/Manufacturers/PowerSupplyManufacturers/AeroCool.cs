using PerfectSite.Data.Products;

namespace PerfectSite.Data.Manufacturers.PowerSupplyManufacturers
{
    public class AeroCool : PowerSupplyManufacturer
    {
        public AeroCool()
        {
            Products = new List<PowerSupply>();
        }
    }
}