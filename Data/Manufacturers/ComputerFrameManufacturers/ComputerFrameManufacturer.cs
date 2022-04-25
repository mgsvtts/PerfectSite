using WebApplication1.Data.Products;
using WebApplication1.Data.VirtualClasses;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.ManufacturersComputerFrameManufacturers
{
    public class ComputerFrameManufacturer : VirtualManufacturer
    {
        public List<ComputerFrame> Products { get; set; }
    }
}