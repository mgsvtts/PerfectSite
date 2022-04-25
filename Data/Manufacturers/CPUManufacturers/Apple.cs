using WebApplication1.Data.Products;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Manufacturers.CPUManufacturers
{
    public class Apple : CPUManufacturer
    {
        public Apple()
        {
            Products = new List<CPU>();
        }
    }
}