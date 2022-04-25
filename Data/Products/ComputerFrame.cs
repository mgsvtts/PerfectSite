using WebApplication1.Data.ManufacturersComputerFrameManufacturers;
using WebApplication1.Data.VirtualClasses;

namespace WebApplication1.Data.Products
{
    public class ComputerFrame : VirtualProduct
    {
        public ComputerFrameManufacturer Manufacturer { get; set; }
        public string Size { get; set; }
        public double GPULength { get; set; }
    }
}