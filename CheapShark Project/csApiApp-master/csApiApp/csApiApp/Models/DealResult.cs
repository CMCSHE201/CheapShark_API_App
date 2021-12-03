using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace csApiApp.Models
{
    public class DealResult : GameResultClass
    {
        [JsonProperty("normalPrice")]
        public float NormalPrice { get; set; }

        [JsonProperty("salePrice")]
        public float SalePrice { get; set; }
    }
}