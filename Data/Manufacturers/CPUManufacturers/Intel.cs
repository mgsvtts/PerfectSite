using PerfectSite.Data.Products;

namespace PerfectSite.Data.Manufacturers.CPUManufacturers
{
    public class Intel : CPUManufacturer
    {
        public Intel()
        {
            Products = new List<CPU>();
        }
    }
}