﻿using System.Threading.Tasks;
using MedicalExamination.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MedicalExaminationWeb.Controllers
{
    public sealed class AuthorizationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthorizationController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var model = new LoginModel();

            return View(model);
        }
        
        //[Route("~/api/login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            ApplicationUser user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
                return View(model);
            

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            return Ok(result.Succeeded ?  new {success = true, error = string.Empty } : new {success = false, error = "Неверный логин или пароль."});
        }
    }
}
