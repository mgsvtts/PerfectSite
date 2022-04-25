using WebApplication1.Data.Products;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Manufacturers.PhoneManufacturers
{
    public class Apple : PhoneManufacturer
    {
        public Apple()
        {
            Products = new List<Phone>();
        }
    }
}