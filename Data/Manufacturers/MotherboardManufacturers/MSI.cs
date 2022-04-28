using PerfectSite.Data.Products;

namespace PerfectSite.Data.Manufacturers.MotherboardManufacturers
{
    public class MSI : MotherboardManufacturer
    {
        public MSI()
        {
            Products = new List<Motherboard>();
        }
    }
}