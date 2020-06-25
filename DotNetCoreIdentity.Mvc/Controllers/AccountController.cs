using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreIdentity.Mvc.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreIdentity.Mvc.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _sigInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public AccountController(SignInManager<IdentityUser> sigInManager, UserManager<IdentityUser> userManager)
        {
            _sigInManager = sigInManager;
            _userManager = userManager;
        }
        // GET: AccountController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: AccountController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: AccountController/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            try
            {
                //return RedirectToAction(nameof(Index));
                if (ModelState.IsValid)
                {
                    IdentityUser user = new IdentityUser
                    {
                        UserName = viewModel.UserName
                    };
                    var result = await _userManager.CreateAsync(user, viewModel.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                return View(viewModel);
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Login(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            var user = _userManager.FindByNameAsync(viewModel.UserName);
            if (user != null)
            {
                var result = await _sigInManager.PasswordSignInAsync(viewModel.UserName, viewModel.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "用户名/密码不正确");
            return View(viewModel);
        }
        // POST: AccountController/Delete/5
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _sigInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
     
        }
    }
}
