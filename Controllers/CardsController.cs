using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TradingCardventory.Models;
using TradingCardventory.Services;
using TradingCardventory.Utilities;

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
        public IActionResult SearchForCardsByName()
        {
            return View(new Card());
        }

        [HttpPost]
        public IActionResult SearchForCardsByName(Card card)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("SearchForCardsResult", new { cardName = card.CardName });
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

        public IActionResult SearchForCardsResult(string cardName)
        {
            var listOfCards = pokemonTcgService.GetCardsByName(cardName);
            return View(listOfCards);
        }

        [HttpGet]
        public IActionResult AddCard(Card card)
        {
            return View(card);
        }

        public IActionResult AddCardPost(Card card)
        {
            AddCardToUser(card, HttpContext.Session.GetString("UserId"));
            TempData["AddCardSuccess"] = "You have successfully added your card!";
            return RedirectToAction("MyCards", "Home");
        }
    }
}
