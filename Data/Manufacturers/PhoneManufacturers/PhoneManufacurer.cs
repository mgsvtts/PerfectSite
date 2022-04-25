using WebApplication1.Data.Products;
using WebApplication1.Data.VirtualClasses;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Data.Manufacturers.PhoneManufacturers
{
    public class PhoneManufacturer : VirtualManufacturer
    {
        public List<Phone> Products { get; set; }
    }
}