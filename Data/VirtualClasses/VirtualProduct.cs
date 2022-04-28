using WebApplication1.Data.Products;

namespace WebApplication1.Data.VirtualClasses
{
    public class VirtualProduct
    {

        public int Id { get; set; }
        public virtual string? ModelName { get; set; }
        public string? Description { get; set; }
        public virtual int? ManufacturerId { get; set; }
        public virtual VirtualManufacturer? Manufacturer { get; set; }
        public virtual decimal Price { get; set; }
        public virtual int? Amount { get; set; }
        public virtual int? BoughtTimes { get; set; }
    }
}