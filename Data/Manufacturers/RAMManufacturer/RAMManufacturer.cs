using PerfectSite.Data.Products;
using PerfectSite.Data.VirtualClasses;

namespace PerfectSite.Data.Manufacturers.RAMManufacturer
{
    public class RAMManufacturer : VirtualManufacturer
    {
        public List<RAM> Products { get; set; }
    }
}