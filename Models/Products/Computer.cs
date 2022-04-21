namespace WebApplication1.Models.Products
{
    public class Computer : AbstractProduct
    {
        public override int Id { get; set; }
        public override string ModelName { get; set; }
        public override string Manufacturer { get; set; }
        public override decimal Price { get; set; }
        public override int Amount { get; set; }
        public int CPUId { get; set; }
        public CPU CPU { get; set; }
        public int? GPUId { get; set; }
        public GPU? GPU { get; set; }
        public int RAMId { get; set; }
        public RAM RAM { get; set; }
        public int MotherboardId { get; set; }
        public Motherboard Motherboard { get; set; }
        public int? HDDId { get; set; }
        public HDD? HDD { get; set; }
        public int? SSDId { get; set; }
        public SSD? SSD { get; set; }
        public int PowerSupplyId { get; set; }
        public PowerSupply PowerSupply { get; set; }
        public int FrameId { get; set; }
        public ComputerFrame Frame { get; set; }
    }
}