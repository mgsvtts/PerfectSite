using Microsoft.AspNetCore.Mvc;
using WebApplication1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Controllers
{
    public class CabinetController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public CabinetController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //[HttpGet]
        //[Route("[controller]/[action]")]
        //public async Task<IActionResult> Main()
        //{
        //    //User user = await _userManager.FindByIdAsync(id);
        //    return RedirectToAction("Main", "Cabinet");
        //    //return View("MainGet");
        //}

        [Route("[controller]/[action]")]
        public async Task<IActionResult> Main(string id)
        {
            User result = await _userManager.FindByIdAsync(id);
            if(result != null)
            {
                return View(result);
            }

            ModelState.AddModelError("", "Произошла непредвиденная ошибка");
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> ChangePassword(string id)
        {

            User user = await _userManager.FindByIdAsync(id);
            ChangePasswordViewModel model = new ChangePasswordViewModel { Id = user.Id, Email = user.Email };//, Password = user.Password};
            return View(model);
        }

        [HttpPost]
        [Route("[controller]/[action]")]
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
                       // return Content(user.Password);
                        return RedirectToAction("Main", "Cabinet", user.Id);
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Пользователь не найден");
                }
            }
            return View(model);
        }
    }
}
