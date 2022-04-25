using WebApplication1.Data.Products;

namespace WebApplication1.Data.Manufacturers.RAMManufacturer
{
    public class CORSAIR : RAMManufacturer
    {
        public CORSAIR()
        {
            Products = new List<RAM>();
        }
    }
}