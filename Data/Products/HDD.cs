using PerfectSite.Data.Manufacturers.HDDManufacturers;
using PerfectSite.Data.VirtualClasses;
using System.ComponentModel.DataAnnotations;

namespace PerfectSite.Data.Products
{
    public class HDD : VirtualProduct
    {
        [Required(ErrorMessage = "Введите имя производителя")]
        public HDDManufacturer? Manufacturer { get; set; }

        [Required(ErrorMessage = "Введите интерфейс")]
        public string? Interface { get; set; }

        [Required(ErrorMessage = "Введите пропускную способность")]
        public double? Bandwidth { get; set; }
    }
}