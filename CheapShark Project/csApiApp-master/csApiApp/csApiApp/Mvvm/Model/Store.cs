using Newtonsoft.Json;
using SQLite;

namespace csApiApp.Models
{
    public class Store
    {
        [PrimaryKey, AutoIncrement]
        [JsonProperty("storeID")]
        public int StoreID { get; set; }

        [JsonProperty("storeName")]
        public string StoreName { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        // SQLite ignores this property.
        [Ignore]
        [JsonProperty("images")]
        public StoreImageSet Images { get; set; }

        // Ignore when deserializing json
        [JsonIgnore]
        public string Banner
        { get { return Images.Banner; } set { Images.Banner = value; } }

        [JsonIgnore]
        public string Logo
        { get { return Images.Logo; } set { Images.Logo = value; } }

        [JsonIgnore]
        public string Icon
        { get { return Images.Icon; } set { Images.Icon = value; } }

        public override string ToString()
        {
            return $"{StoreName} ({StoreID})";
        }
    }

    public class StoreImageSet
    {
        [JsonProperty("banner")]
        public string Banner { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        public override string ToString()
        {
            return $"{Banner} {Logo} {Icon}";
        }
    }
}