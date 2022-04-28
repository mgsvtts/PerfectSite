using PerfectSite.Data.Manufacturers.PhoneManufacturers;
using PerfectSite.Data.VirtualClasses;

namespace PerfectSite.Data.Products
{
    public class Phone : VirtualProduct
    {
        public PhoneManufacturer Manufacturer { get; set; }
    }
}