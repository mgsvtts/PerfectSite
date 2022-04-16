using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models.Products
{
    public class GPU : AbstractProduct
    {
        override public int Id { get; set; }
        override public string ModelName { get; set; }
        override public string Manufacturer { get; set; }
        override public decimal Price { get; set; }
        public int MemorySize { get; set; }
        public string MemoryType { get; set; }
        public int MemoryFrequency { get; set; }
        public string GPUrequency { get; set; }
        public double Size { get; set; }

    }
}
