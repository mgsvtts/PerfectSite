using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
