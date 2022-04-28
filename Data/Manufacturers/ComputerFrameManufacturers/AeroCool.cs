using PerfectSite.Data.ManufacturersComputerFrameManufacturers;
using PerfectSite.Data.Products;

namespace PerfectSite.Data.Manufacturers.ComputerFrameManufacturers
{
    public class AeroCool : ComputerFrameManufacturer
    {
        public AeroCool()
        {
            Products = new List<ComputerFrame>();
        }
    }
}