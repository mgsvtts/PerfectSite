using WebApplication1.Data.Products;

namespace WebApplication1.Data.Manufacturers.RAMManufacturer
{
    public class Kingston : RAMManufacturer
    {
        public Kingston()
        {
            Products = new List<RAM>();
        }
    }
}