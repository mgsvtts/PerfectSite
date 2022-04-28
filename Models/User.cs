using Microsoft.AspNetCore.Identity;

namespace PerfectSite.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}