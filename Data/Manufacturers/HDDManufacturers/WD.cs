using PerfectSite.Data.Products;

namespace PerfectSite.Data.Manufacturers.HDDManufacturers
{
    public class WD : HDDManufacturer
    {
        public WD()
        {
            Products = new List<HDD>();
        }
    }
}