using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public abstract class AbstractProduct
    {
        abstract public int Id { get; set; }
        abstract public string ModelName { get; set; }
        abstract public string Manufacturer { get; set; }
        abstract public decimal Price { get; set; }
    }
}
