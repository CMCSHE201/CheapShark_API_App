using System;
using Newtonsoft.Json;

namespace csApiApp
{
    public class GameResultClass
    {
        [JsonProperty("gameID")]
        public int GameID { get; set; }

        [JsonProperty("steamAppID")]
        public int SteamAppID { get; set; }

        [JsonProperty("cheapest")]
        public float Cheapest { get; set; }

        [JsonProperty("cheapestDealID")]
        public string CheapestDealID { get; set; }

        [JsonProperty("external")]
        public string External { get; set; }

        [JsonProperty("internalName")]
        public string InternalName { get; set; }

        [JsonProperty("thumb")]
        public string Thumbnail { get; set; }

    }
}