using WebApplication1.Data.ManufacturersComputerFrameManufacturers;
using WebApplication1.Data.Products;

namespace WebApplication1.Data.Manufacturers.ComputerFrameManufacturers
{
    public class AeroCool : ComputerFrameManufacturer
    {
        public AeroCool()
        {
            Products = new List<ComputerFrame>();
        }
    }
}