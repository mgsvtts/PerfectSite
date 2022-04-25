using WebApplication1.Data.Products;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.ManufacturersComputerFrameManufacturers
{
    public class Thermaltake : ComputerFrameManufacturer
    {
        public Thermaltake()
        {
            Products = new List<ComputerFrame>();
        }
    }
}