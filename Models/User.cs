using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; } 

        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
