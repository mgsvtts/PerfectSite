﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
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


        [Required(ErrorMessage = "Повторите пароль"), Compare("Password", ErrorMessage = "Пароли не совпадают"), MinLength(6, ErrorMessage = "Минимальная длина пароля = 6")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Введите адресс электронной почты")]
        [EmailAddress]
        public string? Email { get; set; }


        [Phone]
        public string? PhoneNumber { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime? BirthDate { get; set; }
    }
}