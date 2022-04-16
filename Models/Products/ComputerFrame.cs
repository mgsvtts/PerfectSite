using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models.Products
{
    public class ComputerFrame : AbstractProduct
    {
        override public int Id { get; set; }
        override public string ModelName { get; set; }
        override public string Manufacturer { get; set; }
        override public decimal Price { get; set; }
        public string Size { get; set; }
        public double GPULength { get; set; }
    }
}
