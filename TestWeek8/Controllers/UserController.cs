using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TestWeek8.Core.Interfaces;
using TestWeek8.Core.Models;
using TestWeek8.Models;

namespace TestWeek8.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly IMainBusinessLayer bl;

        public UserController(IMainBusinessLayer mainBL)
        {
            bl = mainBL;
        }

        public IActionResult Login(string returnURL)
        {
            return View(new UserLoginViewModel { ReturnUrl = returnURL });
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel uvm)
        {
            if (uvm == null)
            {
                return View("ExceptionError", new ResultBL(false, "Invalid User"));
            }

            var user = bl.GetUserByEmail(uvm.Email);
            if (user != null && ModelState.IsValid)
            {
                //Verifica Password
                if (user.Password.Equals(uvm.Password))
                {
                    //UTENTE AUTENTICATO
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role.ToString())
                    };

                    var authProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                        RedirectUri = uvm.ReturnUrl
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties
                    );
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError(nameof(uvm.Password), "Incorrect Password");
                    return View(uvm);
                }
            }
            else
            {
                ModelState.AddModelError(nameof(uvm.Email), "Invalid Email");
                return View(uvm);
            }

            return View(uvm);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult Forbidden()
        {
            return View();
        }

        
    }

}
