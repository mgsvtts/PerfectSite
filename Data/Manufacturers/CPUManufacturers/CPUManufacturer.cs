using WebApplication1.Data.Products;
using WebApplication1.Data.VirtualClasses;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Manufacturers.CPUManufacturers
{
    public class CPUManufacturer : VirtualManufacturer
    {
        public List<CPU> Products { get; set; }
    }
}