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
            sb_Search.SearchButtonPressed += (s, e) => SearchDeal(sb_Search.Text);
        }

        private void SearchDeal(string text)
        {
            //search_Result = text;
            //search_Result_Text.Text = search_Result;
        }

        private async void InitDealOfTheDay()
        {
            List<GameResultClass> dealsOfTheDay = await _restService.GetDealsAsync(Constants.DealOfTheDayEndpoint);
            dealOfTheDayText.Text = "Deal of the Day! - " + dealsOfTheDay[0].Title + " - Normal Price: " + dealsOfTheDay[0].NormalPrice + " - Sale Price: " + dealsOfTheDay[0].SalePrice;
            //collectionView.ItemsSource = dealOfTheDay;
        }
    }
}