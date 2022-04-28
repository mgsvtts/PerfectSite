using PerfectSite.Data.Products;
using PerfectSite.Data.VirtualClasses;

namespace PerfectSite.Data.Manufacturers.CPUManufacturers
{
    public class CPUManufacturer : VirtualManufacturer
    {
        public List<CPU> Products { get; set; }
    }
}