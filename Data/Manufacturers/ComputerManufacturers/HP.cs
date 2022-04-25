using WebApplication1.Data.ManufacturersComputerManufacturers;
using WebApplication1.Data.Products;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Manufacturers.ComputerManufacturers
{
    public class HP : ComputerManufacturer
    {
        public HP()
        {
            Products = new List<Computer>();
        }
    }
}