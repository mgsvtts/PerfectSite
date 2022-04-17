namespace WebApplication1.Models.Products
{
    public class ComputerFrame : AbstractProduct
    {
        public override int Id { get; set; }
        public override string ModelName { get; set; }
        public override string Manufacturer { get; set; }
        public override decimal Price { get; set; }
        public string Size { get; set; }
        public double GPULength { get; set; }
    }
}