using PerfectSite.Data.Manufacturers.PowerSupplyManufacturers;
using PerfectSite.Data.VirtualClasses;
using System.ComponentModel.DataAnnotations;

namespace PerfectSite.Data.Products
{
    public class PowerSupply : VirtualProduct
    {
        [Required(ErrorMessage = "Введите имя производителя")]
        public PowerSupplyManufacturer? Manufacturer { get; set; }

        [Required(ErrorMessage = "Введите мощность")]
        public int? Power { get; set; }

        [Required(ErrorMessage = "Введите сертификат")]
        public string? Certificate { get; set; }
    }
}