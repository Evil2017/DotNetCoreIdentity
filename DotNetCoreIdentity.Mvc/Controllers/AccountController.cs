using DotNetCoreIdentity.Mvc.Models;
using DotNetCoreIdentity.Mvc.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DotNetCoreIdentity.Mvc.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        //登陆
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "用户名/密码错误");
            return View(loginViewModel);
        }
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        //{
        //    ViewData["ReturnUrl"] = returnUrl;
        //    if (model.Email.IndexOf('@') > -1)
        //    {
        //        //Validate email format
        //        string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
        //                               @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
        //                                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        //        Regex re = new Regex(emailRegex);
        //        if (!re.IsMatch(model.Email))
        //        {
        //            ModelState.AddModelError("Email", "Email is not valid");
        //        }
        //    }
        //    else
        //    {
        //        //validate Username format
        //        string emailRegex = @"^[a-zA-Z0-9]*$";
        //        Regex re = new Regex(emailRegex);
        //        if (!re.IsMatch(model.Email))
        //        {
        //            ModelState.AddModelError("Email", "Username is not valid");
        //        }
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        var userName = model.Email;
        //        if (userName.IndexOf('@') > -1)
        //        {
        //            var user = await _userManager.FindByEmailAsync(model.Email);
        //            if (user == null)
        //            {
        //                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        //                return View(model);
        //            }
        //            else
        //            {
        //                userName = user.UserName;
        //            }
        //        }
        //        var result = await _signInManager.PasswordSignInAsync(userName, model.Password, model.RememberMe, lockoutOnFailure: false);
        //    }
        //    return Ok();
        //}
        //注册
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email,
                    PhoneNumber = registerViewModel.PhoneNumber,

                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                };

                var result = await _userManager.CreateAsync(user, registerViewModel.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                return View(registerViewModel);
            }

            return View(registerViewModel);
        }

        //登出
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
