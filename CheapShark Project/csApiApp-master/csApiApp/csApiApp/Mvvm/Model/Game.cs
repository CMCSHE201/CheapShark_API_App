using Newtonsoft.Json;
using SQLite;

namespace csApiApp.Models
{
    public class Game
    {
        [PrimaryKey]
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

        [JsonProperty("steamAppID", NullValueHandling = NullValueHandling.Ignore)]
        public string SteamAppID { get; set; }

        [JsonProperty("releaseDate")]
        public int ReleaseDate { get; set; }

        [JsonProperty("thumb")]
        public string ThumbnailLink { get; set; }
    }
}