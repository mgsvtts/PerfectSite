using PerfectSite.Data.Products;

namespace PerfectSite.Data.Manufacturers.PhoneManufacturers
{
    public class Apple : PhoneManufacturer
    {
        public Apple()
        {
            Products = new List<Phone>();
        }
    }
}