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
                card.Series = item.set.series;
                card.ImageUrl = item.images.small;

                collection.Add(card);
            }
            return collection;
        }
    }
}
