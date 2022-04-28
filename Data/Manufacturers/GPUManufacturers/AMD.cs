using PerfectSite.Data.Products;

namespace PerfectSite.Data.Manufacturers.GPUManufacturers
{
    public class AMD : GPUManufacturer
    {
        public AMD()
        {
            Products = new List<GPU>();
        }
    }
}