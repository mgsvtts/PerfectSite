using PerfectSite.Data.Products;

namespace PerfectSite.Data.Manufacturers.HDDManufacturers
{
    public class Seagate : HDDManufacturer
    {
        public Seagate()
        {
            Products = new List<HDD>();
        }
    }
}