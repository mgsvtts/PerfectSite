using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Data.Products;
using WebApplication1.Data.VirtualClasses;

namespace WebApplication1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}