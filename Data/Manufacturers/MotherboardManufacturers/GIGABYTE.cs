using WebApplication1.Data.Products;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Manufacturers.MotherboardManufacturers
{
    public class GIGABYTE : MotherboardManufacturer
    {
        public GIGABYTE()
        {
            Products = new List<Motherboard>();
        }
    }
}