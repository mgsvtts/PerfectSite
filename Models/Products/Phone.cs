namespace WebApplication1.Models
{
    public class Phone : AbstractProduct
    {
        public override int Id { get; set; }
        public override string ModelName { get; set; }
        public override string Manufacturer { get; set; }
        public override decimal Price { get; set; }
    }
}