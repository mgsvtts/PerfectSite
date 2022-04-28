using PerfectSite.Data.Products;
using PerfectSite.Data.VirtualClasses;

namespace PerfectSite.Data.Manufacturers.MotherboardManufacturers
{
    public class MotherboardManufacturer : VirtualManufacturer
    {
        public List<Motherboard> Products { get; set; }
    }
}