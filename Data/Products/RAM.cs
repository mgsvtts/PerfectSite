using PerfectSite.Data.Manufacturers.RAMManufacturer;
using PerfectSite.Data.VirtualClasses;
using System.ComponentModel.DataAnnotations;

namespace PerfectSite.Data.Products
{
    public class RAM : VirtualProduct
    {
        [Required(ErrorMessage = "Введите имя производителя")]
        public RAMManufacturer? Manufacturer { get; set; }

        [Required(ErrorMessage = "Введите частоту")]
        public double? Speed { get; set; }

        [Required(ErrorMessage = "Введите объем памяти")]
        public int? MemorySize { get; set; }
    }
}