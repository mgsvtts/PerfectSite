using PerfectSite.Data.Manufacturers.PhoneManufacturers;
using PerfectSite.Data.VirtualClasses;
using System.ComponentModel.DataAnnotations;

namespace PerfectSite.Data.Products
{
    public class Phone : VirtualProduct
    {
        [Required(ErrorMessage = "Введите имя производителя")]
        public PhoneManufacturer? Manufacturer { get; set; }
    }
}