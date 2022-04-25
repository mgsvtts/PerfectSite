using WebApplication1.Data.Products;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Manufacturers.PhoneManufacturers
{
    public class Samsung : PhoneManufacturer
    {
        public Samsung()
        {
            Products = new List<Phone>();
        }
    }
}