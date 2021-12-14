namespace csApiApp.Services.Rest.Endpoints
{
    public static class Constants
    {
        public const string DealOfTheDayEndpoint = "https://www.cheapshark.com/api/1.0/deals?sortBy=Savings&pageSize=1&lowerPrice=0.0001";

        public const string StoreListEndpoint = "https://www.cheapshark.com/api/1.0/stores";

        public const string searchStartPoint = "https://www.cheapshark.com/api/1.0/games?title=";
        public const string searchEndPoint = "&limit=60&exact=0";
    }
}