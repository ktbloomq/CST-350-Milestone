using CST_350_Milestone.Models;
using CST_350_Milestone.Services;
using Microsoft.AspNetCore.Mvc;

namespace CST_350_Milestone.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public void ProcessLogin(UserModel user)
        {
            SecurityDAO securityDAO = new SecurityDAO();
            if (securityDAO.FindUserByNameAndPassword(user))
            {
                Response.Redirect("../game");
            } else
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
            SecurityDAO securityDAO = new SecurityDAO();
            if (securityDAO.RegisterUser(user))
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
