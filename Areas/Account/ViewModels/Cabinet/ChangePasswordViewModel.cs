using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PerfectSite.Areas.Account.ViewModels.Cabinet
{
    public class ChangePasswordViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Введите адресс электронной почты")]
        [EmailAddress(ErrorMessage = "Некорректный формат адреса")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите старый пароль")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Введите новый пароль"), MinLength(6, ErrorMessage = "Минимальная длина пароля = 6")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Повторите пароль")]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}