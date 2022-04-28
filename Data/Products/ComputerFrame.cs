using PerfectSite.Data.ManufacturersComputerFrameManufacturers;
using PerfectSite.Data.VirtualClasses;

namespace PerfectSite.Data.Products
{
    public class ComputerFrame : VirtualProduct
    {
        public ComputerFrameManufacturer Manufacturer { get; set; }
        public string Size { get; set; }
        public double GPULength { get; set; }
    }
}