using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels.Cabinet;

namespace WebApplication1.Controllers
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

            return RedirectToAction("Main", "Cabinet");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    IdentityResult result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Main", "Cabinet", user.Id);
                    }
                }
                ModelState.AddModelError(string.Empty, "Пользователь не найден");
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

            return RedirectToAction("Main", "Cabinet");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeEmail(ChangeEmailViewModel model)
        {
            User user = await _userManager.FindByIdAsync(model.Id);

            User checkUser = await _userManager.FindByEmailAsync(model.NewEmail);
            if (checkUser == null)
            {
                if (user.Email != model.NewEmail)
                {
                    var token = await _userManager.GenerateChangeEmailTokenAsync(user, model.NewEmail);

                    await _userManager.ChangeEmailAsync(user, model.NewEmail, token.ToString());

                    return RedirectToAction("Main", "Cabinet");
                }
                ModelState.AddModelError(string.Empty, "Новая почта не должна совпадать со старой");
                return View(model);
            }

            ModelState.AddModelError(string.Empty, "Пользователь с такой почтой уже зарегестрирован");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeFirstName(string id)
        {
            User user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                ChangeNameViewModel model = new ChangeNameViewModel { Id = user.Id, OldName = user.FirstName, ChangingLabel = "FirstName" };
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
                ChangeNameViewModel model = new ChangeNameViewModel { Id = user.Id, OldName = user.FirstName, ChangingLabel = "SecondName" };
                return View(model);
            }

            return RedirectToAction("Main", "Cabinet");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeName(ChangeNameViewModel model)
        {
            string currentPage = "Change" + model.ChangingLabel;

            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);

                if (model.ChangingLabel == "FirstName" && model.OldName != model.NewName)
                {
                    user.FirstName = model.NewName;

                    await _db.SaveChangesAsync();

                    return RedirectToAction("Main", "Cabinet");
                }
                else if (model.ChangingLabel == "SecondName" && model.OldName != model.NewName)
                {
                    user.SecondName = model.NewName;

                    await _db.SaveChangesAsync();

                    return RedirectToAction("Main", "Cabinet");
                }

                ModelState.AddModelError(string.Empty, "Новое имя не должно совпадать со старым");

                return RedirectToAction(currentPage, model);
            }

            return RedirectToAction(currentPage, model);
        }
    }
}