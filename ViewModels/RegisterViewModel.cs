using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Введите имя"), MaxLength(50, ErrorMessage = "Длина должна быть меньше 50")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Введите фамилию"), MaxLength(50, ErrorMessage = "Длина должна быть меньше 50")]
        public string SecondName { get; set; }


        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Повторите пароль"), Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Введите адресс электронной почты")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }


        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime? BirthDate { get; set; }

        [DataType(DataType.Url)]
        public string ReturnUrl { get; set; }
    }
}
