using WebApplication1.Data.Products;
using WebApplication1.Data.VirtualClasses;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.ManufacturersComputerManufacturers
{
    public class ComputerManufacturer : VirtualManufacturer
    {
        public List<Computer> Products { get; set; }
    }
}