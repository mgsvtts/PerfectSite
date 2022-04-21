namespace WebApplication1.Models.Products
{
    public abstract class AbstractProduct
    {
        public abstract int Id { get; set; }
        public abstract string ModelName { get; set; }
        public abstract string Manufacturer { get; set; }
        public abstract decimal Price { get; set; }
        public abstract int Amount { get; set; }
    }
}