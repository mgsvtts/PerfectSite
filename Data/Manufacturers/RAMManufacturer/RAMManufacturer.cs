using WebApplication1.Data.Products;
using WebApplication1.Data.VirtualClasses;

namespace WebApplication1.Data.Manufacturers.RAMManufacturer
{
    public class RAMManufacturer : VirtualManufacturer
    {
        public List<RAM> Products { get; set; }
    }
}