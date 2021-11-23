using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceDonkey.Models.Apod
{
    public class ApodResponse
    {
        public ApodResponse(string internalName, string title, string metacriticLink, string dealID, int storeID, int gameID, float salePrice, float normalPrice, int isOnSale, float savings, int metacriticScore, string steamRatingText, int steamRatingPercent, int steamRatingCount, int steamAppID, int releaseDate, int lastChange, float dealRating, string thumbnail)
        {

            InternalName = internalName;
            Title = title;
            MetacriticLink = metacriticLink;
            DealID = dealID;
            StoreID = storeID;
            GameID = gameID;
            SalePrice = salePrice;
            NormalPrice = normalPrice;
            IsOnSale = isOnSale;
            Savings = savings;
            MetacriticScore = metacriticScore;
            SteamRatingText = steamRatingText;
            SteamRatingPercent = steamRatingPercent;
            SteamRatingCount = steamRatingCount;
            SteamAppID = steamAppID;
            ReleaseDate = releaseDate;
            LastChange = lastChange;
            DealRating = dealRating;
            Thumbnail = thumbnail;
        }

        public string InternalName { get; }
        public string Title { get; }
        public string MetacriticLink { get; }
        public string DealID { get; }
        public int StoreID { get; }
        public int GameID { get; }
        public float SalePrice { get; }
        public float NormalPrice { get; }
        public int IsOnSale { get; }
        public float Savings { get; }
        public int MetacriticScore { get; }
        public string SteamRatingText { get; }
        public int SteamRatingPercent { get; }
        public int SteamRatingCount { get; }
        public int SteamAppID { get; }
        public int ReleaseDate { get; }
        public int LastChange { get; }
        public float DealRating { get; }
        public string Thumbnail { get; }

    }
}
