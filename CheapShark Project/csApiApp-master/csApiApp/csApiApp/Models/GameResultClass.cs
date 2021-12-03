using Newtonsoft.Json;

namespace csApiApp
{
    public class GameResultClass
    {
        [JsonProperty("gameID")]
        public int GameId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}