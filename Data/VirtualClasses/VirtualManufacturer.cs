using System.ComponentModel.DataAnnotations;

namespace PerfectSite.Data.VirtualClasses
{
    public class VirtualManufacturer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите имя производителя")]
        public virtual string Name { get; set; }

        public List<VirtualProduct> Products { get; set; }
    }
}