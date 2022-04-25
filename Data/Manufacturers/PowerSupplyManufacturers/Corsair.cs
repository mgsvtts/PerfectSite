using WebApplication1.Data.Products;

namespace WebApplication1.Data.Manufacturers.PowerSupplyManufacturers
{
    public class Corsair : PowerSupplyManufacturer
    {
        public Corsair()
        {
            Products = new List<PowerSupply>();
        }
    }
}