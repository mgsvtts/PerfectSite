using Microsoft.AspNetCore.Mvc;
using PerfectSite.CustomUtilities;
using System.ComponentModel.DataAnnotations;

namespace PerfectSite.Areas.Account.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Введите имя"), MaxLength(50, ErrorMessage = "Длина должна быть меньше 50")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введите фамилию"), MaxLength(50, ErrorMessage = "Длина должна быть меньше 50")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Введите пароль"), MinLength(6, ErrorMessage = "Минимальная длина пароля = 6")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Повторите пароль"), Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Введите адресс электронной почты")]
        [EmailAddress(ErrorMessage = "Некорректный формат адреса")]
        public string? Email { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }

        [UserBirthDateValidation]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime JoinedDate { get; set; }

        public string? ReturnUrl { get; set; }
    }
}