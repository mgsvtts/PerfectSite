using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
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
        [Route("[controller]/[action]")]
        public IActionResult Register(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    SecondName = model.SecondName,
                    Password = model.Password,
                    ConfirmPassword = model.ConfirmPassword,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    BirthDate = model.BirthDate
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);

                    if (!string.IsNullOrEmpty((string)ViewData["ReturnUrl"]) && Url.IsLocalUrl((string)ViewData["ReturnUrl"]))
                    {
                        return Redirect((string)ViewData["ReturnUrl"]);
                    }

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }


        [HttpGet]
        [Route("[controller]/[action]")]
        public IActionResult LoginAsync(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        [HttpPost]
        [Route("[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty((string)ViewData["ReturnUrl"]) && Url.IsLocalUrl((string)ViewData["ReturnUrl"]))
                    {
                        return Redirect((string)ViewData["ReturnUrl"]);
                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Неправильный логин и (или) пароль");
            }
            return View(model);
        }


        [HttpPost]
        [Route("[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> Authenticated(AuthenticatedViewModel model)
        {
            return View(model);
        }


        [HttpPost]
        [Route("[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Authenticated()
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Main", "Cabinet");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}