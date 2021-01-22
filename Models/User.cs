using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingCardventory.Models
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Card> UserCards { get; set; }
        public string UserId { get; set; }
        public List<Card> WishList { get; set; }
    }
}