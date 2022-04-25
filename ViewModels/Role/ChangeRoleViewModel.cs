using Microsoft.AspNetCore.Identity;

namespace WebApplication1.ViewModels.Role
{
    public class ChangeRoleViewModel
    {
        public string UserId { get; set; }

        public string UserEmail { get; set; }

        public List<IdentityRole> AllRoles { get; set; }

        public IList<string> UserRoles { get; set; }

        public ChangeRoleViewModel()
        {
            AllRoles = new List<IdentityRole>();
            UserRoles = new List<string>();
        }
    }
}