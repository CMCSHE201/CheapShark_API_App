using Newtonsoft.Json;

namespace csApiApp.Models
{
    public class StoreResult
    {
        [JsonProperty("storeID")]
        public int StoreID { get; }

        [JsonProperty("storeName")]
        public string StoreName { get; }

        [JsonProperty("isActive")]
        public bool IsActive { get; }

        [JsonProperty("images")]
        public StoreImageSet Images { get; }


        public StoreResult(int storeID, string storeName, bool isActive, StoreImageSet images)
        {
            StoreID = storeID;
            StoreName = storeName;
            IsActive = isActive;
            Images = images;
        }
    }

    public class StoreImageSet
    {
        [JsonProperty("banner")]
        public string Banner { get; }

        [JsonProperty("logo")]
        public string Logo { get; }

        [JsonProperty("icon")]
        public string Icon { get; }

        public StoreImageSet(string banner, string logo, string icon)
        {
            Banner = banner;
            Logo = logo;
            Icon = icon;
        }
    }
}