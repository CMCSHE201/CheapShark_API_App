using Newtonsoft.Json;

namespace csApiApp
{
    public class GameResultClass
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("normalPrice")]
        public float NormalPrice { get; set; }

        [JsonProperty("salePrice")]
        public float SalePrice { get; set; }
    }
}