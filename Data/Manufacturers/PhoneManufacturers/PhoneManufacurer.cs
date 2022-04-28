using PerfectSite.Data.Products;
using PerfectSite.Data.VirtualClasses;

namespace PerfectSite.Data.Manufacturers.PhoneManufacturers
{
    public class PhoneManufacturer : VirtualManufacturer
    {
        public List<Phone> Products { get; set; }
    }
}