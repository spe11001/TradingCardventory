using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using TradingCardventory.Models;
using TradingCardventory.Models.ServiceModels;

namespace TradingCardventory.Services
{
    public class PokemonTcgService
    {
        public GetCardByNameServiceResponse GetCardByName(string name)
        {
            //This is where we are going to call the PokemonTCG API
            using (var client = new HttpClient()) //HttpClient is an object from .NET framework to call to API
            {
                var response = client.GetAsync("https://api.pokemontcg.io/v2/cards?q=name:" + name).Result;
                var responseContent = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<GetCardByNameServiceResponse>(responseContent);
            }
        }
            
    }
}
