using PerfectSite.Data.Manufacturers.GPUManufacturers;
using PerfectSite.Data.VirtualClasses;
using System.ComponentModel.DataAnnotations;

namespace PerfectSite.Data.Products
{
    public class GPU : VirtualProduct
    {
        [Required(ErrorMessage = "Введите имя производителя")]
        public GPUManufacturer? Manufacturer { get; set; }

        [Required(ErrorMessage = "Введите объем памяти")]
        public int? MemorySize { get; set; }

        [Required(ErrorMessage = "Введите тип памяти")]
        public string? MemoryType { get; set; }

        [Required(ErrorMessage = "Введите частоту памяти")]
        public double? MemoryFrequency { get; set; }

        [Required(ErrorMessage = "Введите частоту графического ядра")]
        public double? GPUFrequency { get; set; }

        [Required(ErrorMessage = "Введите длину видеокарты")]
        public double? Size { get; set; }
    }
}