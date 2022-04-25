using WebApplication1.Data.Products;

namespace WebApplication1.Data.Manufacturers.PowerSupplyManufacturers
{
    public class Thermaltake : PowerSupplyManufacturer
    {
        public Thermaltake()
        {
            Products = new List<PowerSupply>();
        }
    }
}