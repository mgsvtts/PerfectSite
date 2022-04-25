using WebApplication1.Data.Products;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.ManufacturersComputerFrameManufacturers
{
    public class Zalman : ComputerFrameManufacturer
    {
        public Zalman()
        {
            Products = new List<ComputerFrame>();
        }
    }
}