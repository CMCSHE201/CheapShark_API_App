using csApiApp.Models;
using csApiApp.Services.Rest;
using csApiApp.Services.Rest.Endpoints;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace csApiApp.Mvvm.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchResultsPage : ContentPage
    {
        private CheapSharkAPI _cheapSharkAPI;

        public SearchResultsPage(CheapSharkAPI cheapSharkAPI)
        {
            _cheapSharkAPI = cheapSharkAPI;

            InitSearchBar();
        }

        private void InitSearchBar()
        {
            sb_Search.SearchButtonPressed += (s, e) => Search(sb_Search.Text);
        }

        private async void Search(string text)
        {
            string url = Constants.searchStartPoint + text + Constants.searchEndPoint;
            List<GameResult> repositories = await _cheapSharkAPI.GetSearchAsync(url);

            collectionView.ItemsSource = repositories;
        }

    }
}