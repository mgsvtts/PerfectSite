namespace WebApplication1.Models.Products
{
    public class CPU : AbstractProduct
    {
        public override int Id { get; set; }
        public override string ModelName { get; set; }
        public override string Manufacturer { get; set; }
        public override decimal Price { get; set; }
        public double Speed { get; set; }
        public string Socket { get; set; }
        public int Cores { get; set; }
        public int Threads { get; set; }
        public int PowerUsage { get; set; }
    }
}