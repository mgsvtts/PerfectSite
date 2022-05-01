using PerfectSite.Data.Manufacturers.MotherboardManufacturers;
using PerfectSite.Data.VirtualClasses;
using System.ComponentModel.DataAnnotations;

namespace PerfectSite.Data.Products
{
    public class Motherboard : VirtualProduct
    {
        [Required(ErrorMessage = "Введите имя производителя")]
        public MotherboardManufacturer? Manufacturer { get; set; }

        [Required(ErrorMessage = "Введите сокет")]
        public string? Socket { get; set; }

        [Required(ErrorMessage = "Введите колличество слотов памяти")]
        public int? MemorySlots { get; set; }

        [Required(ErrorMessage = "Введите тип памяти")]
        public string? MemoryType { get; set; }

        [Required(ErrorMessage = "Введите форм фактор")]
        public string? FormFactor { get; set; }
    }
}