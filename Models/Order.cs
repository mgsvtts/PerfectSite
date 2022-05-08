﻿namespace PerfectSite.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}