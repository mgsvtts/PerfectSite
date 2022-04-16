using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models.Products
{
    public class PowerSupply : AbstractProduct
    {
        override public int Id { get; set; }
        override public string ModelName { get; set; }
        override public string Manufacturer { get; set; }
        override public decimal Price { get; set; }
        public int Power { get; set; }
        public string Certificate { get; set; }

    }
}
