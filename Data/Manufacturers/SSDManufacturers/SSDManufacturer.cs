using PerfectSite.Data.Products;
using PerfectSite.Data.VirtualClasses;

namespace PerfectSite.Data.Manufacturers.SSDManufacturers
{
    public class SSDManufacturer : VirtualManufacturer
    {
        public List<SSD> Products { get; set; }
    }
}