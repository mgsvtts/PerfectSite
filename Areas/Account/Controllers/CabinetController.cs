using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectSite.Areas.Account.ViewModels.Cabinet;
using PerfectSite.Models;

namespace PerfectSite.Areas.Account.Controllers
{
    [Authorize]
    public class CabinetController : Controller
    {
        private readonly ApplicationContext _db;
        private readonly UserManager<User> _userManager;

        public CabinetController(UserManager<User> userManager, ApplicationContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<IActionResult> Main(string id, string? returnUrl = null)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                MainViewModel model = new MainViewModel { User = user, ReturnUrl = returnUrl };
                return View("~/Areas/Account/Views/Cabinet/Main.cshtml", model);
            }

            ModelState.AddModelError("", "Произошла непредвиденная ошибка");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword(string id)
        {
            User user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                ChangePasswordViewModel model = new ChangePasswordViewModel { Id = user.Id, Email = user.Email };
                return View("~/Areas/Account/Views/Cabinet/ChangePassword.cshtml", model);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (model.OldPassword == model.NewPassword)
            {
                ModelState.AddModelError("NewPassword", "Новый пароль не должен совпадать со старым");
                return View("~/Areas/Account/Views/Cabinet/ChangePassword.cshtml", model);
            }

            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    IdentityResult result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Main", "Cabinet", new { id = user.Id });
                    }
                }
                ModelState.AddModelError("OldPassword", "Пользователь с таким паролем не найден");
            }
            return View("~/Areas/Account/Views/Cabinet/ChangePassword.cshtml", model);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeEmail(string id)
        {
            User user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                ChangeEmailViewModel model = new ChangeEmailViewModel { Id = user.Id, OldEmail = user.Email };
                return View("~/Areas/Account/Views/Cabinet/ChangeEmail.cshtml", model);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeEmail(ChangeEmailViewModel model)
        {
            User user = await _userManager.FindByIdAsync(model.Id);

            if (user.Email == model.NewEmail)
            {
                ModelState.AddModelError("NewEmail", "Новая почта не должна совпадать со старой");
                return View("~/Areas/Account/Views/Cabinet/ChangeEmail.cshtml", model);
            }

            User checkUser = await _userManager.FindByEmailAsync(model.NewEmail);

            if (checkUser != null)
            {
                ModelState.AddModelError("NewEmail", "Пользователь с такой почтой уже зарегестрирован");
                return View("~/Areas/Account/Views/Cabinet/ChangeEmail.cshtml", model);
            }

            if (ModelState.IsValid)
            {
                string? token = await _userManager.GenerateChangeEmailTokenAsync(user, model.NewEmail);

                await _userManager.ChangeEmailAsync(user, model.NewEmail, token.ToString());

                return RedirectToAction("Main", "Cabinet", new { id = user.Id });
            }
            return View("~/Areas/Account/Views/Cabinet/ChangeEmail.cshtml", model);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeFirstName(string id)
        {
            User user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                ChangeNameViewModel model = new ChangeNameViewModel { Id = user.Id, OldName = user.FirstName };
                return View("~/Areas/Account/Views/Cabinet/ChangeFirstName.cshtml", model);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeFirstName(ChangeNameViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (model.OldName != model.NewName)
                {
                    user.FirstName = model.NewName;

                    await _db.SaveChangesAsync();

                    return RedirectToAction("Main", "Cabinet", new { id = user.Id });
                }

                ModelState.AddModelError("NewName", "Новое имя не должно совпадать со старым");

                return View("~/Areas/Account/Views/Cabinet/ChangeFirstName.cshtml", model);
            }
            return View("~/Areas/Account/Views/Cabinet/ChangeFirstName.cshtml", model);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeSecondName(string id)
        {
            User user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                ChangeNameViewModel model = new ChangeNameViewModel { Id = user.Id, OldName = user.SecondName };
                return View("~/Areas/Account/Views/Cabinet/ChangeSecondName.cshtml", model);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeSecondName(ChangeNameViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (model.OldName != model.NewName)
                {
                    user.SecondName = model.NewName;

                    await _db.SaveChangesAsync();

                    return RedirectToAction("Main", "Cabinet", new { id = user.Id });
                }

                ModelState.AddModelError("NewName", "Новая фамилия не должна совпадать со старой");

                return View("~/Areas/Account/Views/Cabinet/ChangeSecondName.cshtml", model);
            }
            return View("~/Areas/Account/Views/Cabinet/ChangeSecondName.cshtml", model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAccount(string id)
        {
            if (id != null)
            {
                DeleteAccountViewModel model = new DeleteAccountViewModel { Id = id };

                return View("~/Areas/Account/Views/Cabinet/DeleteAccount.cshtml", model);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAccount(DeleteAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);

                if (user == null)
                {
                    ModelState.AddModelError("Email", "Пользователь не найден");
                    return View("~/Areas/Account/Views/Cabinet/DeleteAccount.cshtml", model);
                }

                if (user.Email != model.Email || string.IsNullOrEmpty(model.Email))
                {
                    ModelState.AddModelError("Email", "Неверный адрес электронной почты");
                    return View("~/Areas/Account/Views/Cabinet/DeleteAccount.cshtml", model);
                }

                bool check = await _userManager.CheckPasswordAsync(user, model.Password);
                if (!check)
                {
                    ModelState.AddModelError("Password", "Неверный пароль");
                    return View("~/Areas/Account/Views/Cabinet/DeleteAccount.cshtml", model);
                }

                await _userManager.DeleteAsync(user);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            return View("~/Areas/Account/Views/Cabinet/DeleteAccount.cshtml", model);
        }

        public async Task<IActionResult> MyOrders()
        {
            User user = await _userManager.FindByEmailAsync(User.Identity.Name);

            return View("~/Areas/Account/Views/Cabinet/MyOrders.cshtml", await _db.Orders.Where(u => u.UserId == user.Id).OrderByDescending(x => x.CreatedAt).ToListAsync());
        }
    }
}