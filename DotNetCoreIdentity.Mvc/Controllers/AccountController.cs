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
        private readonly SignInManager<User> _signInManager;

        private readonly UserManager<User> _userManager;

        public AccountController(SignInManager<User> signInManager,UserManager<User> userManager)
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
                var user = new User
                {
                    UserName = registerViewModel.UserName,
                    Name = registerViewModel.Name,
                    Email = registerViewModel.Email,
                    PhoneNumber = registerViewModel.PhoneNumber
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
