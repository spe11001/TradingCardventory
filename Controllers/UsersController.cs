using Microsoft.AspNetCore.Mvc;
using System;
using TradingCardventory.Models;
using TradingCardventory.Utilities;

namespace TradingCardventory.Controllers
{
    public class UsersController : Controller
    {
        private DataBaseAccessUtility dataBaseAccessUtility;

        public UsersController()
        {
            dataBaseAccessUtility = new DataBaseAccessUtility();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View(new User());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                AddUserToDatabase(user);
                ViewBag.UserCreationSuccess = "You have successfully created your user name!";
                return View(new User());
            }
            else
            {
                return View(user);
            }
        }
        public void AddUserToDatabase(User user)
        {
            try
            {
                dataBaseAccessUtility.CreateUserAccount(user);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
