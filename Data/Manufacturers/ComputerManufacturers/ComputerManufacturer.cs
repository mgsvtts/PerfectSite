using PerfectSite.Data.Products;
using PerfectSite.Data.VirtualClasses;

namespace PerfectSite.Data.ManufacturersComputerManufacturers
{
    public class ComputerManufacturer : VirtualManufacturer
    {
        public List<Computer> Products { get; set; }
    }
}