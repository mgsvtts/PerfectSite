using WebApplication1.Data.Manufacturers.PowerSupplyManufacturers;
using WebApplication1.Data.VirtualClasses;

namespace WebApplication1.Data.Products
{
    public class PowerSupply : VirtualProduct
    {
        public PowerSupplyManufacturer Manufacturer { get; set; }
        public int Power { get; set; }
        public string Certificate { get; set; }
    }
}