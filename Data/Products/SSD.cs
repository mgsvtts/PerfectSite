using PerfectSite.Data.Manufacturers.SSDManufacturers;
using PerfectSite.Data.VirtualClasses;
using System.ComponentModel.DataAnnotations;

namespace PerfectSite.Data.Products
{
    public class SSD : VirtualProduct
    {
        [Required(ErrorMessage = "Введите имя производителя")]
        public SSDManufacturer? Manufacturer { get; set; }

        [Required(ErrorMessage = "Введите форм фактор")]
        public double? FormFactor { get; set; }

        [Required(ErrorMessage = "Введите интерфейс")]
        public string? Interface { get; set; }

        [Required(ErrorMessage = "Введите пропускную способность")]
        public double? Bandwidth { get; set; }
    }
}