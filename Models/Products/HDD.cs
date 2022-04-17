﻿namespace WebApplication1.Models.Products
{
    public class HDD : AbstractProduct
    {
        public override int Id { get; set; }
        public override string ModelName { get; set; }
        public override string Manufacturer { get; set; }
        public override decimal Price { get; set; }
        public double FormFactor { get; set; }
        public string Interface { get; set; }
        public double Bandwidth { get; set; }
    }
}