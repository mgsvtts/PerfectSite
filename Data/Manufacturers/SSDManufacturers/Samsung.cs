using WebApplication1.Data.Products;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Manufacturers.SSDManufacturers
{
    public class Samsung : SSDManufacturer
    {
        public Samsung()
        {
            Products = new List<SSD>();
        }
    }
}