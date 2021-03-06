﻿using System.ComponentModel.DataAnnotations;

namespace TradingCardventory.Models
{
    public class Card
    {
        public string CardId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Card name is required")]
        public string CardName { get; set; }
        public string ImageUrl { get; set; }
        public string HighResImg { get; set; }
        public string Supertype { get; set; }
        public string Rarity { get; set; }
        public string Set { get; set; }
        public string SetName { get; set; }
        public decimal MarketValue { get; set; }
    }
}
