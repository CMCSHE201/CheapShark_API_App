using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace csApiApp.Mvvm.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        RestService _restService;

        public string search_Result;

        public HomePage()
        {
            InitializeComponent();
            _restService = new RestService();

            InitSearchBar();
            InitDealOfTheDay();
        }

        private void InitSearchBar()
        {
            sb_Search.SearchButtonPressed += (s, e) => SearchGame(sb_Search.Text);
        }

        private async void SearchGame(string text)
        {
            string url = Constants.searchStartPoint + text + Constants.searchEndPoint;
            List<GameResultClass> searchResults = await _restService.GetGamesAsync(url);
        }

        private async void InitDealOfTheDay()
        {
            List<DealResultClass> dealsOfTheDay = await _restService.GetDealsAsync(Constants.dealOfTheDayEndpoint);
            dealOfTheDayText.Text = "Deal of the Day! - " + dealsOfTheDay[0].Title + " - Normal Price: " + dealsOfTheDay[0].NormalPrice + " - Sale Price: " + dealsOfTheDay[0].SalePrice;
            //collectionView.ItemsSource = dealOfTheDay;
        }
    }
}