using System;
using System.Collections.Generic;
using System.Text;

namespace csApiApp.Models
{
    internal class GameResultClass
    {
        public int gameID;
        public int steamAppID;
        public float cheapestDeal;
        public string cheapestDealID;
        public string externalName;
        public string internalName;
        public string thumbnailLink;

        public int getGameID()
        { return gameID; }

        public void setGameID(int id)
        { gameID = id; }

        public int getSteamAppID()
        { return steamAppID; }

        public void setSteamAppID(int id)
        { steamAppID = id; }

        public float getCheapestDeal()
        { return cheapestDeal; }

        public void setCheapestDeal(float price)
        { cheapestDeal = price; }

        public string getCheapestDealID()
        { return cheapestDealID; }

        public void setCheapestDealID(string id)
        { cheapestDealID = id; }

        public string getExternalName()
        { return externalName; }

        public void setExternalName(string name)
        { externalName = name; }

        public string getInternalName()
        { return internalName; }

        public void setInternalName(string name)
        { internalName = name; }

        public string getThumbnailLink()
        { return thumbnailLink; }

        public void setThumbnailLink(string link)
        { thumbnailLink = link; }
    }
}