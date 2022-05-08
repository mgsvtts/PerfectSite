using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PerfectSite.Areas.Account.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введите почту")]
        [EmailAddress(ErrorMessage = "Некорректный формат адреса")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}