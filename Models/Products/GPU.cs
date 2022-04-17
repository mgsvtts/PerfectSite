namespace WebApplication1.Models.Products
{
    public class GPU : AbstractProduct
    {
        public override int Id { get; set; }
        public override string ModelName { get; set; }
        public override string Manufacturer { get; set; }
        public override decimal Price { get; set; }
        public int MemorySize { get; set; }
        public string MemoryType { get; set; }
        public int MemoryFrequency { get; set; }
        public string GPUrequency { get; set; }
        public double Size { get; set; }
    }
}