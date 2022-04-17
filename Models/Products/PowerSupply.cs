namespace WebApplication1.Models.Products
{
    public class PowerSupply : AbstractProduct
    {
        public override int Id { get; set; }
        public override string ModelName { get; set; }
        public override string Manufacturer { get; set; }
        public override decimal Price { get; set; }
        public int Power { get; set; }
        public string Certificate { get; set; }
    }
}