using WebApplication1.Data.Products;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Manufacturers.PhoneManufacturers
{
    public class Xiaomi : PhoneManufacturer
    {
        public Xiaomi()
        {
            Products = new List<Phone>();
        }
    }
}