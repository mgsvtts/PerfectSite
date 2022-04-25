using WebApplication1.Data.Products;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Manufacturers.HDDManufacturers
{
    public class Toshiba : HDDManufacturer
    {
        public Toshiba()
        {
            Products = new List<HDD>();
        }
    }
}