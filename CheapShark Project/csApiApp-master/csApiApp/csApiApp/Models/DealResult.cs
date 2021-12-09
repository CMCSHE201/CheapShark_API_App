using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace csApiApp.Models
{
    public class DealResult : GameResult
    {
        [JsonProperty("dealID")]
        public string DealID { get; set; }

        [JsonProperty("normalPrice")]
        public float NormalPrice { get; set; }

        [JsonProperty("salePrice")]
        public float SalePrice { get; set; }

        [JsonProperty("storeID")]
        public string StoreID { get; set; }

        [JsonProperty("savings")]
        public string SavingsPercentage { get; set; }
    }
}