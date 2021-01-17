using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingCardventory.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Card> UserCards { get; set; }
    }
}