using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PerfectSite.Areas.Account.ViewModels.Role;
using PerfectSite.Models;

namespace PerfectSite.Areas.Account.Controllers
{
    [Authorize(Roles = "God of the Site")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Main()
        {
            return View("~/Areas/Account/Views/Role/Main.cshtml", _roleManager.Roles.ToList());
        }

        public IActionResult Create() => View("~/Areas/Account/Views/Role/Create.cshtml");

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Main");
                }
                else
                {
                    foreach (IdentityError? error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View("~/Areas/Account/Views/Role/Create.cshtml", name);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }

            return RedirectToAction("Main");
        }

        public IActionResult UserList()
        {
            return View("~/Areas/Account/Views/Role/UserList.cshtml", _userManager.Users.ToList());
        }

        public async Task<IActionResult> Edit(string userId)
        {
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                IList<string>? userRoles = await _userManager.GetRolesAsync(user);
                List<IdentityRole>? allRoles = _roleManager.Roles.ToList();
                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View("~/Areas/Account/Views/Role/Edit.cshtml", model);
            }

            ModelState.AddModelError(string.Empty, "Пользователь не найден");

            return RedirectToAction("UserList", "Role");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                IList<string>? userRoles = await _userManager.GetRolesAsync(user);

                List<IdentityRole>? allRoles = _roleManager.Roles.ToList();

                IEnumerable<string>? addedRoles = roles.Except(userRoles);

                IEnumerable<string>? removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);

                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                return RedirectToAction("UserList");
            }

            ModelState.AddModelError(string.Empty, "Пользователь не найден");

            return RedirectToAction("UserList", "Role");
        }
    }
}