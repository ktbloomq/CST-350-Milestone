using CST_350_Milestone.Models;
using CST_350_Milestone.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Security.Claims;
using NLog;
using CST_350_Milestone.Utility;

namespace CST_350_Milestone.Controllers
{
    public class LoginController : Controller
    {
        
        public IUsersDataService Security { get; set; }

        public LoginController(IUsersDataService securityService)
        {
            Security = securityService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ProcessLogin(UserModel user)
        {
            UserLogger.GetInstance().Info("Entering ProcessLogin Method.");
            UserLogger.GetInstance().Info("Parameter: " + user.ToString());
            if (Security.FindUserByNameAndPassword(user))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));
                UserLogger.GetInstance().Info("Successful Login.");
                return RedirectToAction("Index", "Game");
            }
            else
            {
                UserLogger.GetInstance().Info("Failed Login.");
				return RedirectToAction("Index", "Login");
			}
        }

        public async Task<IActionResult> Logout()
        {
            UserLogger.GetInstance().Info("Logging Out.");
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home"); // Redirect after logout
        }

        public IActionResult RegisterUser()
        {
            return View("RegisterUser");
        }
        [HttpPost]
        public IActionResult ProcessRegister(UserModel user) 
        {
            UserLogger.GetInstance().Info("Entering ProcessRegistration Method.");
            UserLogger.GetInstance().Info("Registration for: " + user.ToString());
            if (Security.RegisterUser(user))
            {
                UserLogger.GetInstance().Info("Successful Registration.");
                return View("RegisterSuccess", user);
            }
            else
            {
                UserLogger.GetInstance().Info("Failed Registration");
                return View("RegisterFailure", user);
            } 
        }
    }
}
