using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PerfectSite.Areas.Account.ViewModels.Account;
using PerfectSite.Models;

namespace PerfectSite.Areas.Account.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string? returnUrl = null)
        {
            return View("~/Areas/Account/Views/Account/Register.cshtml", new RegisterViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(model.Email);
                if (user != null)
                {
                    LoginViewModel loginViewModel = new LoginViewModel
                    {
                        Email = model.Email,
                        Password = model.Password,
                        ReturnUrl = model.ReturnUrl,
                        RememberMe = false
                    };
                    ModelState.AddModelError("Email", "Пользователь уже зарегестрирован, попробуйте войти");
                    return View("~/Areas/Account/Views/Account/Login.cshtml", loginViewModel);
                }

                user = new User
                {
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    SecondName = model.SecondName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    BirthDate = model.BirthDate,
                    JoinedDate = DateTime.Now
                };

                IdentityResult? result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    await _signInManager.SignInAsync(user, false);

                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Данные введены некорректно");
                }

                return View("~/Areas/Account/Views/Account/Register.cshtml", model);
            }

            return View("~/Areas/Account/Views/Account/Register.cshtml", model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl = null)
        {
            return View("~/Areas/Account/Views/Account/Login.cshtml", new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByEmailAsync(model.Email);

                if (user == null)
                {
                    ModelState.AddModelError("Email", "Пользователь с таким адресом не существует");
                    return View("~/Areas/Account/Views/Account/Login.cshtml", model);
                }

                Microsoft.AspNetCore.Identity.SignInResult? result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("Password", "Неверный пароль");
            }
            return View("~/Areas/Account/Views/Account/Login.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(string? returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}