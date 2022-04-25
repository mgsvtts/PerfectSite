using WebApplication1.Data.Products;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Manufacturers.MotherboardManufacturers
{
    public class Asus : MotherboardManufacturer
    {
        public Asus()
        {
            Products = new List<Motherboard>();
        }
    }
}