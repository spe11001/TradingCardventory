using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using TradingCardventory.Models;
using TradingCardventory.Utilities;

namespace TradingCardventory.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private DataBaseAccessUtility dataBaseAccessUtility;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            dataBaseAccessUtility = new DataBaseAccessUtility(); //set the initial value for dataBaseAccessUtility
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserId") != null)//This gets the session UserId's values
            {
                var user = dataBaseAccessUtility.GetUserById(HttpContext.Session.GetString("UserId")); //Geting the user via the session's userId
                return View(user);
            }
            else
            {
                return RedirectToAction("Login"); //redirects to Login action
            }
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User user) //overloading first method, same name, different signatures
        {
            if (ModelState.IsValid) //checks if required properties are entered
            {
                //Get user from database given inputs from Login page

                var loggedInUser = dataBaseAccessUtility.GetLoggedInUser(user.UserName, user.Password);
                if (loggedInUser != null)
                {
                    HttpContext.Session.SetString("UserId", loggedInUser.UserId);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.MyErrorMessage = "Either the username or password is incorrect.";
                }
            }
            return View(user);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult MyCards()
        {
            if (HttpContext.Session.GetString("UserId") != null)//This gets the session UserId's values
            {
                var user = dataBaseAccessUtility.GetUserById(HttpContext.Session.GetString("UserId")); //Geting the user via the session's userId
                return View(user);
            }
            else
            {
                return RedirectToAction("Login"); //redirects to Login action
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
