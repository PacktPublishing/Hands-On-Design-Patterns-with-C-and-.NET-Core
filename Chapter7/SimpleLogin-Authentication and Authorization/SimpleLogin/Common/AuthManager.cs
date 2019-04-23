using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using SimpleLogin.Models;
using SimpleLogin.Persistance;

// ReSharper disable once CheckNamespace
namespace System.Security.Claims
{
    public class AuthManager : IAuthManager
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly HttpContext _httpContext;
        private readonly IUserManager _userManager;
        public AuthManager(IHttpContextAccessor httpContextAccessor,
            IAuthorizationService authorizationService,
            IUserManager userManager)
        {
            _httpContext = httpContextAccessor.HttpContext;
            _authorizationService = authorizationService;
            _userManager = userManager;
        }

        public string UserId
        {
            get
            {
                return User.Identities.FirstOrDefault(u => u.IsAuthenticated)
                    ?.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            }
        }
        public string Name
        {
            get
            {
                return User.Identities.FirstOrDefault(u => u.IsAuthenticated)
                    ?.FindFirst(c => c.Type == ClaimTypes.Name)?.Value;
            }
        }
        public string Email
        {
            get
            {
                return User.Identities.FirstOrDefault(u => u.IsAuthenticated)
                    ?.FindFirst(c => c.Type == ClaimTypes.Email)?.Value;
            }
        }

       
        public bool IsAuthenticated
        {
            get { return User.Identities.Any(u => u.IsAuthenticated); }
        }
        
        public ClaimsPrincipal User => _httpContext?.User;

        public User ApplicationUser => GetApplicationUser();

        public bool Login(LoginViewModel model)
        {
            var user = _userManager.FindBy(model);
            if (user == null) return false;
            SignInCookie(model, user);
            return true;
        }

        public async Task LogoutAsync()
        {
            var defaultCookie = CookieAuthenticationDefaults.AuthenticationScheme;
            await _httpContext.SignOutAsync(defaultCookie);
        }


        /// <summary>
        ///     Returns true when user meets policy requirements
        ///     Based on https://docs.microsoft.com/en-us/aspnet/core/security/authorization/views
        /// </summary>
        /// <param name="policyName"></param>
        /// <returns></returns>
        public async Task<bool> HasPolicy(string policyName)
        {
            var result = await _authorizationService.AuthorizeAsync(User, null, policyName);

            return result.Succeeded;
        }

        public User GetApplicationUser()
        {
            return _userManager.GetBy(UserId);
        }

       
        public bool Add(User user, string password)
        {
            return _userManager.Add(user, password);
        }

        private void SignInCookie(LoginViewModel model, User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Email,user.EmailId),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };

            if (user.Roles != null)
            {
                string[] roles = user.Roles.Split(",");

                claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            }

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var props = new AuthenticationProperties { IsPersistent = model.RememberMe };

            _httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
        }
    }

    public interface IAuthManager
    {
        string Email { get; }
        string UserId { get; }
        string Name { get; }
        bool IsAuthenticated { get; }
        ClaimsPrincipal User { get; }
        User ApplicationUser { get; }

        bool Login(LoginViewModel model);
        Task LogoutAsync();
        
        Task<bool> HasPolicy(string policyName);
        User GetApplicationUser();

        bool Add(User user, string password);
    }
}