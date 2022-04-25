using WebApplication1.Data.Products;
using WebApplication1.Data.VirtualClasses;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Manufacturers.HDDManufacturers
{
    public class HDDManufacturer : VirtualManufacturer
    {
        public List<HDD> Products { get; set; }
    }
}