using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class AuthenticatedViewModel
    {
        
        public string FirstName { get; set; }


        public string SecondName { get; set; }


        public string Password { get; set; }


        public string? Email { get; set; }


        public string? PhoneNumber { get; set; }


        public DateTime? BirthDate { get; set; }
    }
}
