using PerfectSite.Data.Products;
using PerfectSite.Data.VirtualClasses;

namespace PerfectSite.Data.ManufacturersComputerFrameManufacturers
{
    public class ComputerFrameManufacturer : VirtualManufacturer
    {
        public List<ComputerFrame> Products { get; set; }
    }
}