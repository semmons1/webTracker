using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Okta.AspNetCore;

namespace webTracker.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            if(!HttpContext.User.Identity.IsAuthenticated)
            {
                return Challenge(OpenIdConnectDefaults.AuthenticationScheme);
            }
            return RedirectToAction("Index", "Employees");
        }

        public IActionResult Logout()
        {
            return new SignOutResult(new[]
            {
                OpenIdConnectDefaults.AuthenticationScheme,
                CookieAuthenticationDefaults.AuthenticationScheme
            });
        }
    }
}