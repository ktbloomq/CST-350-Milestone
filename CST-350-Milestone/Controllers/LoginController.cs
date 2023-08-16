using CST_350_Milestone.Models;
using CST_350_Milestone.Services;
using Microsoft.AspNetCore.Mvc;

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

        public void ProcessLogin(UserModel user)
        {
            if (Security.FindUserByNameAndPassword(user))
            {
                Response.Redirect("/Game");
            }
            else
            {
				Response.Redirect("./");
			}
        }
        public IActionResult RegisterUser()
        {
            return View("RegisterUser");
        }
        [HttpPost]
        public IActionResult ProcessRegister(UserModel user) 
        {
            if (Security.RegisterUser(user))
            {
                return View("RegisterSuccess", user);
            }
            else
            {
                return View("RegisterFailure", user);
            } 
        }
    }
}
