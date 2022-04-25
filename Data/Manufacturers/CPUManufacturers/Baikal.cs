using WebApplication1.Data.Products;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Manufacturers.CPUManufacturers
{
    public class Baikal : CPUManufacturer
    {
        public Baikal()
        {
            Products = new List<CPU>();
        }
    }
}