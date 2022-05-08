using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PerfectSite.Areas.Store.ViewModels
{
    public class BuyViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Введите адрес доставки")]
        public string Address { get; set; }

        public Guid ProductId { get; set; }

        [Range(1, 10, ErrorMessage = "Нельзя покупать меньше 1 или больше 10 товаров за раз")]
        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}