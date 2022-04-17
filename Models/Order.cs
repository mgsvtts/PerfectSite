namespace WebApplication1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ModelId { get; set; }
        public Phone Phone { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}