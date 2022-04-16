using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models.Products
{
    public class RAM : AbstractProduct
    {
        override public int Id { get; set; }
        override public string ModelName { get; set; }
        override public string Manufacturer { get; set; }
        override public decimal Price { get; set; }
        public double Speed { get; set; }
        public int MemorySize { get; set; }
        public double Bandwidth { get; set; }
    }
}
