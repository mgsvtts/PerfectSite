using System.ComponentModel.DataAnnotations;

namespace PerfectSite.ViewModels.Cabinet
{
    public class DeleteAccountViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Введите почту")]
        [EmailAddress(ErrorMessage = "Некорректный формат адреса")]
        public string Email { get; set; }
    }
}