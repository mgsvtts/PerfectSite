using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectSite.Models;
using PerfectSite.ViewModels.Cabinet;

namespace PerfectSite.Controllers
{
    [Authorize]
    public class CabinetController : Controller
    {
        private readonly ApplicationContext _db;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public CabinetController(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        public async Task<IActionResult> Main(string id)
        {
            User result = await _userManager.FindByIdAsync(id);
            if (result != null)
            {
                return View(result);
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
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if(model.OldPassword == model.NewPassword)
            {
                ModelState.AddModelError("NewPassword", "Новый пароль не должен совпадать со старым");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    IdentityResult result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return View("~/Views/Cabinet/Main.cshtml", user);
                    }
                }
                ModelState.AddModelError("OldPassword", "Пользователь с таким паролем не найден");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeEmail(string id)
        {
            User user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                ChangeEmailViewModel model = new ChangeEmailViewModel { Id = user.Id, OldEmail = user.Email };
                return View(model);
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
                return View(model);
            }

            User checkUser = await _userManager.FindByEmailAsync(model.NewEmail);

            if (checkUser != null)
            {
                ModelState.AddModelError("NewEmail", "Пользователь с такой почтой уже зарегестрирован");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                var token = await _userManager.GenerateChangeEmailTokenAsync(user, model.NewEmail);

                await _userManager.ChangeEmailAsync(user, model.NewEmail, token.ToString());

                return View("~/Views/Cabinet/Main.cshtml", user);
            }
           return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeFirstName(string id)
        {
            User user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                ChangeNameViewModel model = new ChangeNameViewModel { Id = user.Id, OldName = user.FirstName };
                return View(model);
            }

            return RedirectToAction("Main", "Cabinet");
        }

        [HttpGet]
        public async Task<IActionResult> ChangeSecondName(string id)
        {
            User user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                ChangeNameViewModel model = new ChangeNameViewModel { Id = user.Id, OldName = user.SecondName };
                return View(model);
            }

            return RedirectToAction("Main", "Cabinet");
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

                    return RedirectToAction("Main", "Cabinet", user.Id);
                }

                ModelState.AddModelError("NewName", "Новое имя не должно совпадать со старым");

                return View(model);
            }
            return View(model);
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

                    return RedirectToAction("Main", "Cabinet", user.Id);
                }

                ModelState.AddModelError("NewName", "Новое имя не должно совпадать со старым");

                return View(model);
            }
            return View(model);
        }

        public async Task<IActionResult> MyOrders()
        {
            User user = await _userManager.FindByEmailAsync(User.Identity.Name);

            return View(await _db.Orders.Where(u => u.UserId == user.Id).ToListAsync());
        }
    }
}