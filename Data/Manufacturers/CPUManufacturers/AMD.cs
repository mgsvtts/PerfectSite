using WebApplication1.Data.Products;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Manufacturers.CPUManufacturers
{
    public class AMD : CPUManufacturer
    {
        public AMD()
        {
            Products = new List<CPU>();
        }
    }
}