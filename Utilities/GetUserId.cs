using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Utilities
{
    public class Utilities
    {
        private readonly UserManager<User> _userManager;

        public Utilities(UserManager<User> userManager)
        {
            _userManager = userManager;
        }


        public async Task<string> GetUserId(string userName)
        {
            User user = await _userManager.FindByNameAsync(userName);
            if (user != null)
                return user.Id;

            return string.Empty;
        }
    }
}
