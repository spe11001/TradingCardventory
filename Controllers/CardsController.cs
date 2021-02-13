using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TradingCardventory.Models;
using TradingCardventory.Services;
using TradingCardventory.Utilites;

namespace TradingCardventory.Controllers
{
    public class CardsController : Controller
    {
        private DataBaseAccessUtility dataBaseAccessUtility;
        private PokemonTcgService pokemonTcgService;

        public CardsController()
        {
            pokemonTcgService = new PokemonTcgService();
            dataBaseAccessUtility = new DataBaseAccessUtility();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddCard()
        {
            return View(new Card());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCard(Card card)
        {
            if (ModelState.IsValid)
            {
                var listOfCards = pokemonTcgService.GetCardByName(card.CardName);
                var userId = HttpContext.Session.GetString("UserId");
                AddCardToUser(card, userId);
                ViewBag.UserCreationSuccess = "You have successfully added your card!";
                return View(new Card());
            }
            else
            {
                return View(card);
            }
        }
        public void AddCardToUser(Card card, string userId)
        {
            try
            {
                dataBaseAccessUtility.AddCardToUser(card, userId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
