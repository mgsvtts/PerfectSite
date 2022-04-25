using WebApplication1.Data.Products;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.ManufacturersComputerFrameManufacturers
{
    public class CoolerMaster : ComputerFrameManufacturer
    {
        public CoolerMaster()
        {
            Products = new List<ComputerFrame>();
        }
    }
}