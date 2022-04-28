using System.ComponentModel.DataAnnotations;

namespace PerfectSite.ViewModels.Home
{
    public class BuyViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Введите адрес доставки")]
        public string Address { get; set; }

        public int ProductId { get; set; }

        [Range(1, 10, ErrorMessage = "Нельзя покупать меньше 1 или больше 10 товаров за раз")]
        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}