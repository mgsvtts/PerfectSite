using PerfectSite.Data.Products;
using PerfectSite.Data.VirtualClasses;

namespace PerfectSite.Data.Manufacturers.HDDManufacturers
{
    public class HDDManufacturer : VirtualManufacturer
    {
        public List<HDD> Products { get; set; }
    }
}