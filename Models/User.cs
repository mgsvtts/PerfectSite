using Microsoft.AspNetCore.Identity;

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