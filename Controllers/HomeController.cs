using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TradingCardventory.Models;
using TradingCardventory.Utilites;

namespace TradingCardventory.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private DataBaseAccessUtility dataBaseAccessUtility;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            dataBaseAccessUtility = new DataBaseAccessUtility();
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserId") != null)//This gets the session UserId's values
            {
                //Get logged in User with UserId and return correct views
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                //Step 1 Get user from database given inputs from Login page

                var loggedInUser = dataBaseAccessUtility.GetLoggedInUser(user.UserName, user.Password);
                if (loggedInUser != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.MyErrorMessage = "Either the username or password is incorrect.";
                }
            }
            return View(user);
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
