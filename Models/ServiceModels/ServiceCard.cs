using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingCardventory.Models.ServiceModels
{
    public class ServiceCard
    {
        public string id { get; set; }
        public string name { get; set; }
        public string supertype { get; set; }
        public string rarity { get; set; }
        public ServiceSet set { get; set; }
        //public ServiceTcgPlayer tcgplayer { get; set; }
        public ServiceImages images { get; set; }
    }
}
