using WebApplication1.Data.Products;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Manufacturers.CPUManufacturers
{
    public class Intel : CPUManufacturer
    {
        public Intel()
        {
            Products = new List<CPU>();
        }
    }
}