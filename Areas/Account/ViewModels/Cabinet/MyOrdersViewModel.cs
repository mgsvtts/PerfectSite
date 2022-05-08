﻿using Microsoft.AspNetCore.Mvc;

namespace PerfectSite.Areas.Account.ViewModels.Cabinet
{
    public class MyOrdersViewModel
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Quantity { get; set; }
    }
}