using System.Collections.Generic;
using TradingCardventory.Models;
using TradingCardventory.Models.ServiceModels;

namespace TradingCardventory.Mappers
{
    public class GetCardsMapper
    {
        public List<Card> Map(ServiceCard[] serviceCards)
        {
            var collection = new List<Card>();

            foreach (var item in serviceCards)
            {
                var card = new Card();
                card.CardId = item.id;
                card.CardName = item.name;
                card.Supertype = item.supertype;
                card.Rarity = item.rarity;
                card.Set = item.set.id;
                card.SetName = item.set.name;
                card.ImageUrl = item.images.small;
                card.HighResImg = item.images.large;

                collection.Add(card);
            }
            return collection;
        }
    }
}
