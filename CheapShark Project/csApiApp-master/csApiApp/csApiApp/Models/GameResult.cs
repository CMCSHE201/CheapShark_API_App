using Newtonsoft.Json;
using System;

namespace csApiApp
{
    public class GameResult
    {
        [JsonProperty("gameID")]
        public int GameID { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("metacriticlink")]
        public string MetaReviewLink { get; set; }

        [JsonProperty("metacriticScore")]
        public int MetaReviewScore { get; set; }

        [JsonProperty("steamRatingPercent")]
        public float SteamRatingPercent { get; set; }

        [JsonProperty("steamAppID")]
        public int SteamAppID { get; set; }

        [JsonProperty("releaseDate")]
        public int ReleaseDate { get; set; }

        [JsonProperty("thumb")]
        public string ThumbnailLink { get; set; }
    }
}