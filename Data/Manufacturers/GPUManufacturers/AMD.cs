using WebApplication1.Data.Products;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Manufacturers.GPUManufacturers
{
    public class AMD : GPUManufacturer
    {
        public AMD()
        {
            Products = new List<GPU>();
        }
    }
}