using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceDonkey.Models
{
    class GameResultClass
    {
        public string internalName;
        public string title;
        public string metacriticLink;
        public string dealID;
        public int storeID;
        public int gameID;
        public float salePrice;
        public float normalPrice;
        public int isOnSale;
        public float savings;
        public int metacriticScore;
        public string steamRatingText;
        public int steamRatingPercent;
        public int steamRatingCount;
        public int steamAppID;
        public int releaseDate;
        public int lastChange;
        public float dealRating;
        public string thumbnail;

        public string getInternalName { get; }
        public string getTitle { get; }
        public string getMetacriticLink { get; }
        public string getDealID { get; }
        public int getStoreID { get; }
        public int getGameID { get; }
        public float getSalePrice { get; }
        public float getNormalPrice { get; }
        public int getIsOnSale { get; }
        public float getSavings { get; }
        public int getMetacriticScore { get; }
        public string getSteamRatingText { get; }
        public int getSteamRatingPercent { get; }
        public int getSteamRatingCount { get; }
        public int getSteamAppID { get; }
        public int getReleaseDate { get; }
        public int getLastChange { get; }
        public float getDealRating { get; }
        public string getThumbnail { get; }
    }
}
    

