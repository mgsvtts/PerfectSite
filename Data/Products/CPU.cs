using PerfectSite.Data.Manufacturers.CPUManufacturers;
using PerfectSite.Data.VirtualClasses;
using System.ComponentModel.DataAnnotations;

namespace PerfectSite.Data.Products
{
    public class CPU : VirtualProduct
    {
        [Required(ErrorMessage = "Введите имя производителя")]
        public CPUManufacturer? Manufacturer { get; set; }

        [Required(ErrorMessage = "Введите частоту")]
        public double? Speed { get; set; }

        [Required(ErrorMessage = "Введите сокет")]
        public string Socket { get; set; }

        [Required(ErrorMessage = "Введите колличество ядер")]
        public int? Cores { get; set; }

        [Required(ErrorMessage = "Введите колличество потоков")]
        public int? Threads { get; set; }

        [Required(ErrorMessage = "Введите TDP")]
        public int? PowerUsage { get; set; }
    }
}