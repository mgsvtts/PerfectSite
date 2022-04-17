namespace WebApplication1.Models.Products
{
    public class RAM : AbstractProduct
    {
        public override int Id { get; set; }
        public override string ModelName { get; set; }
        public override string Manufacturer { get; set; }
        public override decimal Price { get; set; }
        public double Speed { get; set; }
        public int MemorySize { get; set; }
        public double Bandwidth { get; set; }
    }
}