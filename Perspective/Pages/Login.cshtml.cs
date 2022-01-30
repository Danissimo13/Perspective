using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Perspective.Managers;
using Perspective.Storage.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Perspective.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly IUserManager _userManager;

        public LoginModel(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(string email, string password, string returnUrl)
        {
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch { }

            User user;
            try
            {
                user = await _userManager.FindAsync(email);
            }
            catch (KeyNotFoundException)
            {
                return LocalRedirect($"~/Denied?Message=Not found Email: {email}");
            }

            bool correctPassword = _userManager.CheckPassword(user, password); ;
            if (correctPassword)
            {
                await _userManager.SignInAsync(HttpContext, user);
            }
            else
            {
                return LocalRedirect("~/Denied?Message=Invalid Password");
            }

            if (string.IsNullOrEmpty(returnUrl)) returnUrl = "~/";
            if (returnUrl.StartsWith("~/") == false) returnUrl = $"~/{returnUrl}";
            return LocalRedirect(returnUrl);
        }
    }
}
