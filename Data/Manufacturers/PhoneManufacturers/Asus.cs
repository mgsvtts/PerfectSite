using WebApplication1.Data.Products;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Manufacturers.PhoneManufacturers
{
    public class Asus : PhoneManufacturer
    {
        public Asus()
        {
            Products = new List<Phone>();
        }
    }
}