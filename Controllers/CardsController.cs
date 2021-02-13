using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        [ValidateAntiForgeryToken]
        public IActionResult SearchForCardsByName(Card card)
        {
            if (ModelState.IsValid)
            {
                var listOfCards = pokemonTcgService.GetCardsByName(card.CardName);
                TempData["cards"] = JsonConvert.SerializeObject(listOfCards);
                return RedirectToAction("SearchForCardsResult");
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
        public IActionResult SearchForCardsResult()
        {
            var cards = JsonConvert.DeserializeObject<List<Card>>((string)TempData["cards"]);

            //var cards = TempData["cards"] as List<Card>;
            return View(cards);
        }
    }
}
