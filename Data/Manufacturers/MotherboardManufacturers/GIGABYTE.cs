using PerfectSite.Data.Products;

namespace PerfectSite.Data.Manufacturers.MotherboardManufacturers
{
    public class GIGABYTE : MotherboardManufacturer
    {
        public GIGABYTE()
        {
            Products = new List<Motherboard>();
        }
    }
}