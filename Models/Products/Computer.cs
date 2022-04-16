using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models.Products
{
    public class Computer : AbstractProduct
    {
        override public int Id { get; set; }
        override public string ModelName { get; set; }
        override public string Manufacturer { get; set; }
        
        override public decimal Price { get; set; }
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
