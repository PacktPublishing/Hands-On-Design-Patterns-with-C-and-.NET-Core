using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SimpleLogin.Models;
using SimpleLogin.Persistance;

namespace SimpleLogin.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthManager _authManager;

        public AccountController(IUserManager userManager, IAuthManager authManager)
        {
            _authManager = authManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            var model = new LoginViewModel { ReturnUrl = returnUrl };
            return View(model);
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _authManager.Login(model);

                if (result)
                {
                   return !string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl)
                        ? (IActionResult)Redirect(model.ReturnUrl)
                        : RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Invalid login attempt");
            return View(model);
        }

        private void SignInCookie(LoginViewModel model, User user)
        {
            var claims = new List<Claim> {new Claim(ClaimTypes.Name, user.UserName)};


            string[] roles = user.Roles.Split(",");

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var props = new AuthenticationProperties {IsPersistent = model.RememberMe};

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
        }

        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Username,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmailId = model.EmailId,
                    Mobile = model.Mobile
                };
                var result = _authManager.Add(user,model.Password);

                if (result)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Registration unsuccessful!");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _authManager.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
