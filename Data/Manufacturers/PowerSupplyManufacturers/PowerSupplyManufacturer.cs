using WebApplication1.Data.Products;
using WebApplication1.Data.VirtualClasses;

namespace WebApplication1.Data.Manufacturers.PowerSupplyManufacturers
{
    public class PowerSupplyManufacturer : VirtualManufacturer
    {
        public List<PowerSupply> Products { get; set; }
    }
}