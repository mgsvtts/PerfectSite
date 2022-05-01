using PerfectSite.Data.ManufacturersComputerFrameManufacturers;
using PerfectSite.Data.VirtualClasses;
using System.ComponentModel.DataAnnotations;

namespace PerfectSite.Data.Products
{
    public class ComputerFrame : VirtualProduct
    {
        [Required(ErrorMessage = "Введите имя производителя")]
        public ComputerFrameManufacturer? Manufacturer { get; set; }

        [Required(ErrorMessage = "Введите форм фактор")]
        public string? Size { get; set; }

        [Required(ErrorMessage = "Введите максимальную длину видеокарты")]
        [Range(0, 1000, ErrorMessage = "Длина не может быть меньше нуля и больше 1 000")]
        public double? GPULength { get; set; }
    }
}