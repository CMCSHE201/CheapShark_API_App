using Newtonsoft.Json;

namespace csApiApp.Models
{
    public class DealResult : GameResult
    {
        [JsonProperty("dealID")]
        public string DealID { get; }

        [JsonProperty("normalPrice")]
        public decimal NormalPrice { get; }

        [JsonProperty("salePrice")]
        public decimal SalePrice { get; }

        [JsonProperty("storeID")]
        public string StoreID { get; }

        [JsonProperty("savings")]
        public float SavingsPercentage { get; }

        public DealResult(int gameID, string title, string metaReviewLink, int metaReviewScore, float steamRatingPercent, string steamAppID, int releaseDate, string thumbnailLink, string dealID, decimal normalPrice, decimal salePrice, string storeID, float savingsPercentage)
            : base(gameID, title, metaReviewLink, metaReviewScore, steamRatingPercent, steamAppID, releaseDate, thumbnailLink)
        {
            DealID = dealID;
            NormalPrice = normalPrice;
            SalePrice = salePrice;
            StoreID = storeID;
            SavingsPercentage = savingsPercentage;
        }
    }
}