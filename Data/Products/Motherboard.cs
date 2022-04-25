using WebApplication1.Data.Manufacturers.MotherboardManufacturers;
using WebApplication1.Data.VirtualClasses;

namespace WebApplication1.Data.Products
{
    public class Motherboard : VirtualProduct
    {
        public MotherboardManufacturer Manufacturer { get; set; }
        public string Socket { get; set; }
        public int MemorySlots { get; set; }
        public string MemoryType { get; set; }
        public string FormFactor { get; set; }
    }
}