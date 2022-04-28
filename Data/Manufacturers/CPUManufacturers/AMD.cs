using PerfectSite.Data.Products;

namespace PerfectSite.Data.Manufacturers.CPUManufacturers
{
    public class AMD : CPUManufacturer
    {
        public AMD()
        {
            Products = new List<CPU>();
        }
    }
}