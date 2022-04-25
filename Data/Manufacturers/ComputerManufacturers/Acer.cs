using WebApplication1.Data.Products;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.ManufacturersComputerManufacturers
{
    public class Acer : ComputerManufacturer
    {
        public Acer()
        {
            Products = new List<Computer>();
        }
    }
}