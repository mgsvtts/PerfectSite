using WebApplication1.Data.Products;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Manufacturers.SSDManufacturers
{
    public class SanDisk : SSDManufacturer
    {
        public SanDisk()
        {
            Products = new List<SSD>();
        }
    }
}