using Newtonsoft.Json;
using System;

namespace csApiApp
{
    public class GameResult
    {
        //[JsonProperty("gameID")]
        public int GameID { get; }

        //[JsonProperty("title")]
        public string Title { get; }

        //[JsonProperty("metacriticlink")]
        public string MetaReviewLink { get; }

        //[JsonProperty("metacriticScore")]
        public int MetaReviewScore { get; }

        //[JsonProperty("steamRatingPercent")]
        public float SteamRatingPercent { get; }

        //[JsonProperty("steamAppID")]
        public int SteamAppID { get; }

        //[JsonProperty("releaseDate")]
        public int ReleaseDate { get; }

        [JsonProperty("thumb")]
        public string ThumbnailLink { get; }

        public GameResult(int gameID, string title, string metaReviewLink, int metaReviewScore, float steamRatingPercent, int steamAppID, int releaseDate, string thumbnailLink)
        {
            GameID = gameID;
            Title = title;
            MetaReviewLink = metaReviewLink;
            MetaReviewScore = metaReviewScore;
            SteamRatingPercent = steamRatingPercent;
            SteamAppID = steamAppID;
            ReleaseDate = releaseDate;
            ThumbnailLink = thumbnailLink;
        }
    }
}