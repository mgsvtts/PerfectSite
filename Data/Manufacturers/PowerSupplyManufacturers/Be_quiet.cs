using WebApplication1.Data.Products;

namespace WebApplication1.Data.Manufacturers.PowerSupplyManufacturers
{
    public class Be_quiet : PowerSupplyManufacturer
    {
        public Be_quiet()
        {
            Products = new List<PowerSupply>();
        }
    }
}