using WebApplication1.Data.Products;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Manufacturers.HDDManufacturers
{
    public class WD : HDDManufacturer
    {
        public WD()
        {
            Products = new List<HDD>();
        }
    }
}