using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace csApiApp.Mvvm.Model
{
    class SearchResult
    {
        [JsonProperty("gameID")]
        public int GameID { get; }

        [JsonProperty("steamAppID")]
        public string SteamAppID { get; }

        [JsonProperty("cheapest")]
        public float Cheapest { get; }

        [JsonProperty("cheapestDealID")]
        public string CheapestDealID { get; }

        [JsonProperty("external")]
        public string External { get; }

        [JsonProperty("thumb")]
        public string Thumb { get; }

        public SearchResult(int gameID, string steamAppID, float cheapest, string cheapestDealID, string external, string thumb)
        {
            GameID = gameID;
            SteamAppID = steamAppID;
            Cheapest = cheapest;
            CheapestDealID = cheapestDealID;
            External = external;
            Thumb = thumb;
        }
    }
}
