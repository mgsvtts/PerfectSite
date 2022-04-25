using WebApplication1.Data.Products;
using WebApplication1.Data.VirtualClasses;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Manufacturers.GPUManufacturers
{
    public class GPUManufacturer : VirtualManufacturer
    {
        public List<GPU> Products { get; set; }
    }
}