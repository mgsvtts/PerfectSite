using WebApplication1.Data.Products;

namespace WebApplication1.Data.Manufacturers.PowerSupplyManufacturers
{
    public class AeroCool : PowerSupplyManufacturer
    {
        public AeroCool()
        {
            Products = new List<PowerSupply>();
        }
    }
}