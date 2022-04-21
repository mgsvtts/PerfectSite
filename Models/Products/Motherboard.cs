namespace WebApplication1.Models.Products
{
    public class Motherboard : AbstractProduct
    {
        public override int Id { get; set; }
        public override string ModelName { get; set; }
        public override string Manufacturer { get; set; }
        public override decimal Price { get; set; }
        public override int Amount { get; set; }
        public int Socket { get; set; }
        public int MemorySlots { get; set; }
        public string MemoryType { get; set; }
        public string FormFactor { get; set; }
    }
}