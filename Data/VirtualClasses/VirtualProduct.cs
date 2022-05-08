using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerfectSite.Data.VirtualClasses
{
    public class VirtualProduct
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public virtual string? ModelName { get; set; }
        public string? Description { get; set; }
        public virtual int? ManufacturerId { get; set; }
        public virtual VirtualManufacturer? Manufacturer { get; set; }

        [Required(ErrorMessage = "Укажите цену")]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Цена не может быть меньше нуля")]
        public virtual decimal? Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Колличество не может быть меньше нуля")]
        public virtual int? Amount { get; set; }

        public virtual int? BoughtTimes { get; set; }
    }
}