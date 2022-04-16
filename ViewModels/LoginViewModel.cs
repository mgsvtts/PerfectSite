using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введите почту")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "Запомнить меня?")]
        public bool RememberMe { get; set; }

        [DataType(DataType.Url)]
        public string ReturnUrl { get; set; }
    }
}
