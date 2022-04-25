using WebApplication1.Data.Products;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Manufacturers.MotherboardManufacturers
{
    public class ASRock : MotherboardManufacturer
    {
        public ASRock()
        {
            Products = new List<Motherboard>();
        }
    }
}