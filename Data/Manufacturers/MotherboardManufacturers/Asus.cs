using PerfectSite.Data.Products;

namespace PerfectSite.Data.Manufacturers.MotherboardManufacturers
{
    public class Asus : MotherboardManufacturer
    {
        public Asus()
        {
            Products = new List<Motherboard>();
        }
    }
}