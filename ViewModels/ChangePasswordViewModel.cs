using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string Id { get; set; }


        [Required(ErrorMessage = "Введите адресс электронной почты")]
        [EmailAddress]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        public string OldPassword { get; set; }


        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }


        [Required(ErrorMessage = "Повторите пароль"), Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}