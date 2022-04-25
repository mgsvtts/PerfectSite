using WebApplication1.Data.Products;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Manufacturers.GPUManufacturers
{
    public class Nvidia : GPUManufacturer
    {
        public Nvidia()
        {
            Products = new List<GPU>();
        }
    }
}