using WebApplication1.Data.Products;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Manufacturers.MotherboardManufacturers
{
    public class MSI : MotherboardManufacturer
    {
        public MSI()
        {
            Products = new List<Motherboard>();
        }
    }
}