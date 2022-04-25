using WebApplication1.Data.Products;
using WebApplication1.Data.VirtualClasses;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Manufacturers.MotherboardManufacturers
{
    public class MotherboardManufacturer : VirtualManufacturer
    {
        public List<Motherboard> Products { get; set; }
    }
}