using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models.Products
{
    public class CPU : AbstractProduct
    {
        override public int Id { get; set; }
        override public string ModelName { get; set; }
        override public string Manufacturer { get; set; }
        override public decimal Price { get; set; }
        public double Speed { get; set; }
        public string Socket { get; set; }
        public int Cores { get; set; }
        public int Threads { get; set; }
        public int PowerUsage { get; set; }
    }
}
