using PerfectSite.Data.Products;

namespace PerfectSite.Data.Manufacturers.PhoneManufacturers
{
    public class Samsung : PhoneManufacturer
    {
        public Samsung()
        {
            Products = new List<Phone>();
        }
    }
}