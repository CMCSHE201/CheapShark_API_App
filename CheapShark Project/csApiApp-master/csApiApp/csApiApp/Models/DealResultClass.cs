using System;
using Newtonsoft.Json;

namespace csApiApp
{
    class DealResultClass
    {
        [JsonProperty("internalName")]
        public string InternalName { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("metacriticLink")]
        public string MetacriticLink { get; set; }

        [JsonProperty("dealID")]
        public string DealID { get; set; }

        [JsonProperty("storeID")]
        public int StoreID { get; set; }

        [JsonProperty("gameID")]
        public int GameID { get; set; }

        [JsonProperty("salePrice")]
        public float SalePrice { get; set; }

        [JsonProperty("normalPrice")]
        public float NormalPrice { get; set; }

        [JsonProperty("isOnSale")]
        public int IsOnSale { get; set; }

        [JsonProperty("savings")]
        public float Savings { get; set; }

        [JsonProperty("metacriticScore")]
        public int MetacriticScore { get; set; }

        [JsonProperty("steamRatingText")]
        public string SteamRatingText { get; set; }

        [JsonProperty("steamRatingPercent")]
        public int SteamRatingPercent { get; set; }

        [JsonProperty("steamRatingCount")]
        public int SteamRatingCount { get; set; }

        [JsonProperty("steamAppID")]
        public int SteamAppID { get; set; }

        [JsonProperty("releaseDate")]
        public int ReleaseDate { get; set; }

        [JsonProperty("lastChange")]
        public int LastChange { get; set; }

        [JsonProperty("dealRating")]
        public float DealRating { get; set; }

        [JsonProperty("thumb")]
        public string Thumbnail { get; set; }


    }
}
