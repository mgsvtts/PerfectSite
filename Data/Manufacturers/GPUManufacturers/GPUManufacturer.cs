using PerfectSite.Data.Products;
using PerfectSite.Data.VirtualClasses;

namespace PerfectSite.Data.Manufacturers.GPUManufacturers
{
    public class GPUManufacturer : VirtualManufacturer
    {
        public List<GPU> Products { get; set; }
    }
}