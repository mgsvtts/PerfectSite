using WebApplication1.Data.Products;
using WebApplication1.Data.VirtualClasses;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Manufacturers.SSDManufacturers
{

    public class SSDManufacturer : VirtualManufacturer
    {

        public List<SSD> Products { get; set; }
    }
}