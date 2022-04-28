using PerfectSite.Data.Manufacturers.CPUManufacturers;
using PerfectSite.Data.VirtualClasses;

namespace PerfectSite.Data.Products
{
    public class CPU : VirtualProduct
    {
        public CPUManufacturer Manufacturer { get; set; }
        public double Speed { get; set; }
        public string Socket { get; set; }
        public int Cores { get; set; }
        public int Threads { get; set; }
        public int PowerUsage { get; set; }
    }
}