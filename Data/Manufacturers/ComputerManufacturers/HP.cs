using PerfectSite.Data.ManufacturersComputerManufacturers;
using PerfectSite.Data.Products;

namespace PerfectSite.Data.Manufacturers.ComputerManufacturers
{
    public class HP : ComputerManufacturer
    {
        public HP()
        {
            Products = new List<Computer>();
        }
    }
}