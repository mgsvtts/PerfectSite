using WebApplication1.Data.Manufacturers.PhoneManufacturers;
using WebApplication1.Data.VirtualClasses;

namespace WebApplication1.Data.Products
{
    public class Phone : VirtualProduct
    {
        public PhoneManufacturer Manufacturer { get; set; }
    }
}