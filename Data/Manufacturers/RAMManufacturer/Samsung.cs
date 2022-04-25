using WebApplication1.Data.Products;

namespace WebApplication1.Data.Manufacturers.RAMManufacturer
{
    public class Samsung : RAMManufacturer
    {
        public Samsung()
        {
            Products = new List<RAM>();
        }
    }
}