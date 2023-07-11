using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Starpholio.Areas.Identity.Data;
using Starpholio.Models;
using System.Threading.Tasks;
using Microsoft.Build.Logging;
using Starpholio.Views.Home;

namespace Starpholio.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UserInfo> _userManager;
        private readonly SignInManager<UserInfo> _signInManager;

        public AccountController(UserManager<UserInfo> userManager, SignInManager<UserInfo> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Account/Register
        public IActionResult Register()
        {
            return View();
        }

        //[ValidateAntiForgeryToken]
        // POST: Account/Register
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new UserInfo
                {
                    UserName = model.Username,
                    Email = model.Email,
                    //DateOfBirth = model.DateOfBirth,     
                    //Location = model.Location            //TODO: make location and dateofbirth actually fudging work
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }



        // GET: Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            return RedirectToAction("Index", "LoggedIN"); // Replace "YourController" with the actual controller name

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    //return RedirectToAction("Index", "LoggedIN"); // Replace "YourController" with the actual controller name
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }



        // Helper method to redirect to a local URL or the homepage if the URL is not local
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}