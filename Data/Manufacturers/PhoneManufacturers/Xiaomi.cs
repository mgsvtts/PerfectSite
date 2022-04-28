using PerfectSite.Data.Products;

namespace PerfectSite.Data.Manufacturers.PhoneManufacturers
{
    public class Xiaomi : PhoneManufacturer
    {
        public Xiaomi()
        {
            Products = new List<Phone>();
        }
    }
}