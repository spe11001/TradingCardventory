using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TradingCardventory.Models
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [Required(AllowEmptyStrings=false, ErrorMessage="Username is required")]
        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public List<Card> UserCards { get; set; }
        public string UserId { get; set; }
        public List<Card> WishList { get; set; }
    }
}