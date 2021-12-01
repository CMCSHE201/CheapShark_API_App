using System;
using System.Collections.Generic;
using System.Text;

namespace csApiApp
{
    public static class Constants
    {
        public const string dealOfTheDayEndpoint = "https://www.cheapshark.com/api/1.0/deals?storeID=1&sortBy=Savings";

        public const string searchStartPoint = "https://www.cheapshark.com/api/1.0/games?title=";
        public const string searchEndPoint = "&limit=60&exact=0";
    }
}
