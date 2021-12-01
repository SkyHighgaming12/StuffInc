using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StuffInc.Data;
using StuffInc.Data.Static;
using StuffInc.Data.ViewModels;
using StuffInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Login()
        {
            var response = new LoginVm();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm loginVm)
        {
            if (!ModelState.IsValid) return View(loginVm);
            var user = await _userManager.FindByEmailAsync(loginVm.EmailAddress);
            if(user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVm.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVm.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                TempData["Error"] = "Wrong Email or password, Please Try Again";
                return View(loginVm);
            }

            TempData["Error"] = "Wrong Email or password, Please Try Again";
            return View(loginVm);
        }
        public IActionResult Register()
        {
            var response = new RegisterVm();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm registerVm)
        {
            if (!ModelState.IsValid) return View(registerVm);
            var user = await _userManager.FindByEmailAsync(registerVm.EmailAddress);
            if(user != null)
            {
                TempData["Error"] = "This email is already in use";
                return View(registerVm);
            }
            var newUser = new ApplicationUser()
            {
                Name = registerVm.Name,
                Email = registerVm.EmailAddress,
                UserName = registerVm.EmailAddress
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerVm.Password);

            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            }
            return View("RegisterCompleted");



        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}
