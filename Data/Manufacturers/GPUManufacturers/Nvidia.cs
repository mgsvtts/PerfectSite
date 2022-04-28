using PerfectSite.Data.Products;

namespace PerfectSite.Data.Manufacturers.GPUManufacturers
{
    public class Nvidia : GPUManufacturer
    {
        public Nvidia()
        {
            Products = new List<GPU>();
        }
    }
}