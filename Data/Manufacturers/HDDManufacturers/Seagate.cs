using WebApplication1.Data.Products;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Manufacturers.HDDManufacturers
{
    public class Seagate : HDDManufacturer
    {
        public Seagate()
        {
            Products = new List<HDD>();
        }
    }
}