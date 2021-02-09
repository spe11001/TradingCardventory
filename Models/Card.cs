namespace TradingCardventory.Models
{
    public class Card
    {
        public string CardId { get; set; }
        public string CardName { get; set; }
        public string ImageUrl { get; set; }
        public string Supertype { get; set; }
        public string Rarity { get; set; }
        public string Set { get; set; }
        public string Series { get; set; }
        public decimal MarketValue { get; set; }
    }
}
