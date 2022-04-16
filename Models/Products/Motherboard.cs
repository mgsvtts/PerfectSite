using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models.Products
{
    public class Motherboard : AbstractProduct
    {
        override public int Id { get; set; }
        override public string ModelName { get; set; }
        override public string Manufacturer { get; set; }
        override public decimal Price { get; set; }
        public int Socket { get; set; }
        public int MemorySlots { get; set; }
        public string MemoryType { get; set; }
        public string FormFactor { get; set; }

    }
}
